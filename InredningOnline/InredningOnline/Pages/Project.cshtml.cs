using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InredningOnline.Infrastructure;
using InredningOnline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InredningOnline.Pages
{
    [Authorize(Roles = "user")]
    public class ProjectModel : PageModel
    {
        private readonly IProductRepository repository;

        public ProjectModel(IProductRepository repo, Project projectService)
        {
            repository = repo;
            Project = projectService;
        }

        public Project Project { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/product";
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            
            Project.AddItemToProject(product, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Project.RemoveItemFromProject(Project.ProjectItems.First(p=>
                p.Product.ProductId == productId).Product);
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}
