using Microsoft.AspNetCore.Mvc;
using System.Linq;
using InredningOnline.Models;
using InredningOnline.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace InredningOnline.Controllers
{
    [Authorize(Roles = "user")]
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string category)
        {
            return View(new ProductsListViewModel
            {
                Products = repository.GetProductsByCategory(category),
                CurrentCategory = string.IsNullOrEmpty(category) ? "All Products"
                    : repository.Products.FirstOrDefault(c => c.Category == category)?.Category
            });
        }
    }
}
