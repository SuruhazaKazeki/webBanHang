using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebBanHang.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //them du lieu Categories
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Điện thoại", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Máy tính bảng", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Laptop", DisplayOrder = 3 });

            //them du lieu Product
            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Iphone 7", Price = 300, CategoryId = 1, ImageUrl= "images/products/f4b64997-abfc-428e-ac53-2f58f4a022aa.jpg" },
            new Product { Id = 2, Name = "Iphone 7s", Price = 350, CategoryId = 1, ImageUrl = "images/products/559e0fa1-fce5-41ae-82c5-ad38b1fe92f8.jpg" },
            new Product { Id = 3, Name = "Iphone 8", Price = 400, CategoryId = 1, ImageUrl = "images/products/56ae225d-7c00-405f-b4a1-9b6193888789.jpg" },
            new Product { Id = 4, Name = "Iphone 8s", Price = 420, CategoryId = 1, ImageUrl = "images/products/bf448f8c-9d1c-40d9-a61f-4bc3b0078540.jpg" },
            new Product { Id = 5, Name = "Iphone 12", Price = 630, CategoryId = 1, ImageUrl = "images/products/fca9f033-0ded-4e27-84b0-d0e027b5d03d.jpg" },
            new Product { Id = 6, Name = "Iphone 12 Pro", Price = 750, CategoryId = 1, ImageUrl = "images/products/115934e4-92c5-492d-84ff-0c2852f3ba3c.jpg" },
            new Product { Id = 7, Name = "Iphone 14", Price = 820, CategoryId = 1, ImageUrl = "images/products/dd2e787a-3b40-440e-930b-eab3e3a00c06.jpg" },
            new Product { Id = 8, Name = "Iphone 14 Pro", Price = 950, CategoryId = 1, ImageUrl = "images/products/93b0478f-18d7-42b4-9ffd-e8658cbfbe7f.jpg" },
            new Product { Id = 9, Name = "Iphone 15", Price = 1200, CategoryId = 1, ImageUrl = "images/products/9f71f0bf-7585-4835-875a-396936c9dca4.jpg" },
            new Product { Id = 10, Name = "Iphone 15 Pro Max ", Price = 1450, CategoryId = 1, ImageUrl = "images/products/0c7475e1-6507-4df5-89e4-2d6c893f23eb.jpg" },
            new Product { Id = 11, Name = "Ipad Gen 10", Price = 750, CategoryId = 2, ImageUrl = "images/products/9bae10d4-d035-44eb-9f30-83381a73dd8d.jpg" },
            new Product { Id = 12, Name = "Ipad Pro 11", Price = 1250, CategoryId = 2, ImageUrl = "images/products/fd40ff16-2beb-43bf-bb66-425b3b598ee4.jpg" });
        }
    }
}
