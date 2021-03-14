using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InredningOnline.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InredningOnline.Tests
{
    public class ProjectDetailsRepositoryTests
    {
        private IProjectDetailsRepository _repository;

        private IProjectDetailsRepository getInMEmoryRepository()
        {
            // Create in-memory database
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("test")
                .Options;

            var context = new AppDbContext(options);
            context.ProjectDetails.Add(
                new ProjectDetails
                {
                    ProjectDetailsId = 1,
                    ProjectName = "p1",
                    UserEmail = "currentUser@email.com"
                });
            context.ProjectDetails.Add(
                new ProjectDetails
                {
                    ProjectDetailsId = 2,
                    ProjectName = "p2",
                    UserEmail = "anotherUser@email.com"
                });
            context.ProjectDetails.Add(
                new ProjectDetails
                {
                    ProjectDetailsId = 3,
                    ProjectName = "p3",
                    UserEmail = "currentUser@email.com"
                });
            context.SaveChanges();

            var repository = new ProjectDetailsRepository(context);

            return repository;
        }

        [Theory]
        [InlineData(1, "currentUser@email.com")]
        public void Can_Get_ProjectDetails_Valid(int projectDetailsId,
            string userEmail)
        {
            // Arrange - create a repository
            _repository = getInMEmoryRepository();

            // Act - get a project from repository by Id
            var projectDetails = _repository.GetProjectDetailsById(projectDetailsId);

            // Act - get list of all projects in the repository
            var listOfAllProjects = _repository.ProjectDetails;


            // Act - get list projects for current user
            var listOfProjectsForCurrentUser = _repository
                .GetListOfProjectForCurrentUser(userEmail);

            Assert.Equal(1, projectDetails.ProjectDetailsId);
            Assert.Equal("p1", projectDetails.ProjectName);
            Assert.Equal(3, listOfAllProjects.Count());
            Assert.Equal(2, listOfProjectsForCurrentUser.Count());
        }

       
    }
}
