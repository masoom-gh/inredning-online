using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InredningOnline.Models
{
    public class ProjectDetails
    {
        [BindNever] public int ProjectDetailsId { get; set; }
        public List<ProjectItem> ProjectItems { get; set; }

        [BindNever] public DateTime ProjectCreated { get; set; }

        [BindNever] public string UserEmail { get; set; }
        [BindNever] public string FirstName { get; set; }
        [BindNever] public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a name for the project")] 
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Please enter the project description")]
        public string Description { get; set; }

        public decimal CalculateTotalExpenseOfEachProject()
        {
            return ProjectItems.Sum(p => p.Product.Price * p.Quantity);
        }
    }
}
