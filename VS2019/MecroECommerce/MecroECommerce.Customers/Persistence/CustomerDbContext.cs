using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MecroECommerce.Customers.Persistence
{
    
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {
            if (!this.Customers.Any())
            {
                this.Customers.Add(new Customer() { Id = 1, FirstName = "Customer1", LastName = "Customer1", Email = "Customer1@gmail.com" });
                this.Customers.Add(new Customer() { Id = 2, FirstName = "Customer2", LastName = "Customer2", Email = "Customer2@gmail.com" });
                this.Customers.Add(new Customer() { Id = 3, FirstName = "Customer3", LastName = "Customer3", Email = "Customer3@gmail.com" });
                this.Customers.Add(new Customer() { Id = 4, FirstName = "Customer4", LastName = "Customer4", Email = "Customer4@gmail.com" });
                this.SaveChanges();
            }
        }
    }
}
