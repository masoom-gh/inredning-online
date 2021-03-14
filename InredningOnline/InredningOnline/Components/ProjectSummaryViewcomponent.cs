using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InredningOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace InredningOnline.Components
{
    public class ProjectSummaryViewcomponent : ViewComponent
    {
        private readonly Project project;

        public ProjectSummaryViewcomponent(Project projectService)
        {
            project = projectService;
        }

        public IViewComponentResult Invoke()
        {
            return View(project);
        }
    }
}
