using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InredningOnline.Models
{
    public class AppDbContext: DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed products
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                //ProjectItemId = 1,
                Name = "Simple Table",
                Price = 1300M,
                Description = "This is a simple table.",
                Category = "Furniture",
                Supplier = "Ikea",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                //ProjectItemId = 2,
                Name = "Chair",
                Price = 999M,
                Description = "This is a simple chair.",
                Category = "Furniture",
                Supplier = "Ikea",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                //ProjectItemId = 3,
                Name = "Office Sofa",
                Price = 2999M,
                Description = "This is an office sofa.",
                Category = "Furniture",
                Supplier = "Ikea",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Office Chair",
                Price = 1999M,
                Description = "This is an office chair.",
                Category = "Furniture",
                Supplier = "Mio",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Curtain",
                //ProjectItemId = 4,
                Price = 899M,
                Description = "This is a beautiful curtain.",
                Category = "Furniture",
                Supplier = "Mio",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Tile",
                Price = 299M,
                Description = "This is a tile.",
                Category = "Tiles",
                Supplier = "Clas Ohlson",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "Carpet",
                Price = 7999M,
                Description = "This is a  carpet.",
                Category = "Furniture",
                Supplier = "Mio",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Lighting",
                Price = 1399M,
                Description = "This is lighting.",
                Category = "Tools",
                Supplier = "Clas Ohlson",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Lighting2",
                Price = 2299M,
                Description = "This is lighting 2.",
                Category = "Tools",
                Supplier = "Clas Ohlson",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                Name = "Tile 2",
                Price = 1399M,
                Description = "This is a tile.",
                Category = "Tiles",
                Supplier = "Mio",
            });

        }
        }
    }
