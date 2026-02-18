﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations.Schema;

var _context = new CrmDbContext();

// Initial fetch
var customers = _context.Customers.ToList();

foreach (var cust in customers)
{
    Console.WriteLine($"Customer ID: {cust.CustomerId}, Name: {cust.Name}, Email: {cust.Email}");
}

// Add data
var customer = new Customer
{
    Name = "Swapnil Prasad ",
    Email = "Swapnil@gmail.com"
};

// _context.Customers.Add(customer);
// _context.SaveChanges();

// reload data (IMPORTANT)
customers = _context.Customers.ToList();

// Display again


class CrmDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<CustomerType> CustomerTypes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDB;Integrated Security=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerType>()
            .HasData(
                new CustomerType { Id = 1, TypeName = "Regular" },
                new CustomerType { Id = 2, TypeName = "Premium" }
            );

        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId);
    }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CustomerType
{
    public int Id { get; set; }
    public string TypeName { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}