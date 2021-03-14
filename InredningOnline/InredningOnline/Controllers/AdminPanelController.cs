using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using InredningOnline.Models;

namespace InredningOnline.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {
        private readonly IProjectDetailsRepository repository;

        public AdminPanelController(IProjectDetailsRepository repo)
        {
            repository = repo;
        }

        public IEnumerable<ProjectDetails> AllProjects { get; set; }
        public IActionResult ListAllProjects()
        {
            ViewBag.TableTitle = "All Submitted Projects";

            ViewBag.TotalExpense = repository.CalculateTotalExpenseOfAllProjects();

            AllProjects = repository.ProjectDetails.ToList();
            return View(AllProjects);
        }
    }
}
