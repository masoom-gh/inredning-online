using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public List<ProjectItem> ProjectItems { get; set; } = new List<ProjectItem>();
       
        public virtual void AddItemToProject(Product product, int quantity)
        {
            ProjectItem item = ProjectItems
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (item == null)
            {
                ProjectItems.Add(new ProjectItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public virtual void RemoveItemFromProject(Product product) =>
            ProjectItems.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public decimal CalculateTotalValue() =>
            ProjectItems.Sum(p => p.Product.Price * p.Quantity);

        public virtual void ClearProject() => ProjectItems.Clear();
    }
    public class ProjectItem
    {
        public int ProjectItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
