using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InredningOnline.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace InredningOnline.Models
{
    public class SessionProject : Project
    {
        public static Project GetProject(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionProject project = session?.GetJson<SessionProject>("Project")
                               ?? new SessionProject();
            project.Session = session;
            return project;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItemToProject(Product product, int quantity)
        {
            base.AddItemToProject(product, quantity);
            Session.SetJson("Project", this);
        }

        public override void RemoveItemFromProject(Product product)
        {
            base.RemoveItemFromProject(product);
            Session.SetJson("Project", this);
        }
        public override void ClearProject()
        {
            base.ClearProject();
            Session.Remove("Project");
        }
    }
}
