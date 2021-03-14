using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        Product GetProductById(long productId);

        IQueryable<Product> GetProductsByCategory(string category);
    }
}
