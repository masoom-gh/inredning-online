using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InredningOnline.Models
{
    public class ProjectDetailsRepository : IProjectDetailsRepository
    {
        private readonly AppDbContext context;

        public ProjectDetailsRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<ProjectDetails> ProjectDetails =>
            context.ProjectDetails.Include(items => items.ProjectItems)
                .ThenInclude(item => item.Product);

        public ProjectDetails GetProjectDetailsById(int projectDetailsId)
        {
            return ProjectDetails.FirstOrDefault(p => 
                p.ProjectDetailsId == projectDetailsId);
        }

        public ProjectItem GetProjectItemById(int projectDetailsId, int projectItemId)
        {
            var projectDetails = GetProjectDetailsById(projectDetailsId);
            var projectItem = projectDetails.ProjectItems
                .FirstOrDefault(item => item.ProjectItemId
                                        == projectItemId);
            return projectItem;
        }

        public void SaveProjectDetails(ProjectDetails projectDetails)
        {
            context.AttachRange(projectDetails.ProjectItems.Select(p=>p.Product));
            if (projectDetails.ProjectDetailsId == 0)
            {
                context.ProjectDetails.Add(projectDetails);
            }

            context.SaveChanges();
        }

        public void UpdateProjectDetails()
        {
            context.SaveChanges();
        }

        public decimal CalculateTotalExpenseOfAllProjects()
        {
            decimal total = 0;
            foreach (var project in ProjectDetails)
            {
                total += project.CalculateTotalExpenseOfEachProject();
            }

            return total;
        }

        public IQueryable<ProjectDetails> GetListOfProjectForCurrentUser(string currentUserEmail)
        {
            return ProjectDetails.Where(u => u.UserEmail == currentUserEmail);
        }

        public List<ProjectItem> GetProjectItems(int projectDetailsId)
        {
            return GetProjectDetailsById(projectDetailsId).ProjectItems;
        }

    }
}
