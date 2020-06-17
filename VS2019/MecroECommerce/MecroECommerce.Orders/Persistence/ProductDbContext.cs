using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MecroECommerce.Orders.Persistence
{
    
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions options) : base(options)
        {
            if (!this.Orders.Any())
            {
                this.Orders.Add(new Order() { Id = 1, CustomerId = 1, ProductId = 1 });
                this.Orders.Add(new Order() { Id = 2, CustomerId = 1, ProductId = 2 });
                this.Orders.Add(new Order() { Id = 3, CustomerId = 1, ProductId = 3 });
                this.Orders.Add(new Order() { Id = 4, CustomerId = 1, ProductId = 4 });
                this.SaveChanges();
            }
        }
    }
}
