using InredningOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace InredningOnline.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void Can_Add_New_Item()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            // Arrange - create a new cart
            Project target = new Project();

            // Act
            target.AddItemToProject(p1, 1);
            target.AddItemToProject(p2, 1);
            ProjectItem[] results = target.ProjectItems.ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }

        [Fact]
        public void Can_Add_Quantity_Of_Existing_Items()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1"};
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            // Arrange - create a new project and add items to that
            Project target = new Project();

            // act
            target.AddItemToProject(p1, 1);
            target.AddItemToProject(p2, 2);
            target.AddItemToProject(p1, 5);
            ProjectItem[] results = target.ProjectItems.OrderBy(p=>p.Product.ProductId).ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(6, results[0].Quantity);
            Assert.Equal(2, results[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Item_From_Project()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            // Arrange - create a new project and add items to that
            Project target = new Project();
            target.AddItemToProject(p1, 1);
            target.AddItemToProject(p2, 2);
            target.AddItemToProject(p1, 5);
            target.AddItemToProject(p2, 1);

            // Act
            target.RemoveItemFromProject(p2);

            // Assert
            Assert.Empty(target.ProjectItems.Where(p=>p.Product == p2));
            Assert.Equal(1, target.ProjectItems.Count);
        }

        [Fact]
        public void Calculate_Total_Project_Cost()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1", Price = 400M };
            Product p2 = new Product { ProductId = 2, Name = "P2", Price = 300M };

            // Arrange - create a new cart
            Project target = new Project();

            // Act
            target.AddItemToProject(p1, 2);
            target.AddItemToProject(p2, 4);
            target.AddItemToProject(p1, 1);
            decimal result = target.CalculateTotalValue();

            // Assert
            Assert.Equal(450M, result);
        }

        [Fact]
        public void Can_Clear_Project()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1", Price = 400M };
            Product p2 = new Product { ProductId = 2, Name = "P2", Price = 300M };

            // Arrange - create a new cart and add items to that
            Project target = new Project();
            target.AddItemToProject(p1, 2);
            target.AddItemToProject(p2, 4);

            // Act - empty the project content
            target.ClearProject();

            // Assert
            Assert.Empty(target.ProjectItems);

        }
    }
}
