using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MecroECommerce.Products.Persistence
{
    [Table("Product")]
    public class Product
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Price")]
        public double Price { get; set; }
    }
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
            if (!this.Products.Any())
            {
                this.Products.Add(new Product() { Id = 1, Name = "Product1", Price = 10 });
                this.Products.Add(new Product() { Id = 2, Name = "Product2", Price = 20 });
                this.Products.Add(new Product() { Id = 3, Name = "Product3", Price = 15 });
                this.Products.Add(new Product() { Id = 4, Name = "Product4", Price = 50 });
                this.SaveChanges();
            }
        }
    }
}
