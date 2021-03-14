using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Product> Products => 
            _appDbContext.Products;

        public IQueryable<Product> GetProductsByCategory(string category) =>
            Products.Where(p => category == null || p.Category == category);

        public Product GetProductById(long productId) =>
            Products.FirstOrDefault(pottery => pottery.ProductId == productId);
    }
}
