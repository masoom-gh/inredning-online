using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InredningOnline.Models;
using Microsoft.AspNetCore.Authorization;

namespace InredningOnline.Controllers
{
    [Authorize(Roles = "user")]
    public class UserPanelController : Controller
    {
        private readonly IProjectDetailsRepository repository;

        public UserPanelController(IProjectDetailsRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
           return View();
        }

        public IEnumerable<ProjectDetails> AllProjects;
        public ProjectDetails ProjectDetails;

        public IActionResult ListProjects()
        {
            var currentUserEmail = this.User.Identity.Name;

            AllProjects = repository
                .GetListOfProjectForCurrentUser(currentUserEmail).ToList();

            return View(AllProjects);
        }

        public IActionResult Detail(int projectDetailsId)
        {
            ProjectDetails = repository.GetProjectDetailsById(projectDetailsId);
            if (ProjectDetails == null)
                return NotFound();
            return View(ProjectDetails);
        }

        public IActionResult Edit(int projectDetailsId)
        {
            ProjectDetails = 
                repository.GetProjectDetailsById(projectDetailsId);
            ProjectDetails.ProjectItems = 
                repository.GetProjectItems(projectDetailsId);

            return View(ProjectDetails);
        }

        [HttpPost]
        public IActionResult Edit(ProjectDetails projectDetails, int projectDetailsId)
        {
            if (ModelState.IsValid)
            {
                var targetName = projectDetails.ProjectName;
                var targetDescriptopn = projectDetails.Description;
                var tergetProjectItems = projectDetails.ProjectItems;

                for (int i=0; i < tergetProjectItems.Count; i++)
                {
                    repository.GetProjectDetailsById(projectDetailsId).ProjectItems[i].Quantity =
                        tergetProjectItems[i].Quantity;
                }

                repository.GetProjectDetailsById(projectDetailsId).ProjectName =
                    targetName;
                repository.GetProjectDetailsById(projectDetailsId).Description =
                    targetDescriptopn;

                

                repository.UpdateProjectDetails();

                return RedirectToAction(nameof(ListProjects));
            }

            return View(nameof(Edit));
        }
    }

}
