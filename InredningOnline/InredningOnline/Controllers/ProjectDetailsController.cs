using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using InredningOnline.Areas.Identity.Data;
using InredningOnline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace InredningOnline.Controllers
{
    [Authorize(Roles = "user")]
    public class ProjectDetailsController : Controller
    {
        private readonly IProjectDetailsRepository repository;
        private readonly Project project;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectDetailsController(IProjectDetailsRepository repo,
            Project projectService,
            UserManager<ApplicationUser> userMgr)
        {
            repository = repo;
            project = projectService;
            userManager = userMgr;
        }
        public ViewResult SubmitProject()
        {
            return View(new ProjectDetails());
        }

        [HttpPost]
        public async Task<IActionResult> SubmitProject(ProjectDetails projectDetails)
        {
            if (project.ProjectItems.Count() == 0)
            {
                ModelState.AddModelError("","The project is empty!");
            }

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                projectDetails.FirstName = user.FirstName;
                projectDetails.LastName = user.LastName;
                projectDetails.ProjectItems = project.ProjectItems;
                projectDetails.ProjectCreated = DateTime.Now;
                projectDetails.UserEmail = user.Email;
                repository.SaveProjectDetails(projectDetails);
                project.ClearProject();
                return RedirectToPage("/Completed", 
                    new {projectDetailsId = projectDetails.ProjectDetailsId});
            }
            else
            {
                return View();
            }
        }

        
    }
}
