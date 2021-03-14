using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public interface IProjectDetailsRepository
    {
        IQueryable<ProjectDetails> ProjectDetails { get; }
        void SaveProjectDetails(ProjectDetails projectDetails);
        ProjectDetails GetProjectDetailsById(int projectDetailsId);
        ProjectItem GetProjectItemById(int projectDetailsId, int projectItemId);
        IQueryable<ProjectDetails> GetListOfProjectForCurrentUser(string currentUserEmail);
        public List<ProjectItem> GetProjectItems(int projectDetailsId);
        void UpdateProjectDetails();
        decimal CalculateTotalExpenseOfAllProjects();
    }
}
