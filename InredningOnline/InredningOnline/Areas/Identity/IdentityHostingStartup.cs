using System;
using InredningOnline.Areas.Identity.Data;
using InredningOnline.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(InredningOnline.Areas.Identity.IdentityHostingStartup))]
namespace InredningOnline.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "AuthDB"));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.SignIn.RequireConfirmedAccount = false;
                    })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDbContext>();
            });
        }
    }
}