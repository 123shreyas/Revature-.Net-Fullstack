using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

CrmContext _context = new CrmContext();

var customers = _context.Customers.ToList();

// Without ToList()
// Console.WriteLine("customers.GetType(): " + customers.GetType());
// Console.WriteLine($"Query: {customers.ToQueryString()}");

// With ToList()
// Console.WriteLine("customers.GetType(): " + customers.GetType());

// With AsEnumerable()
// Console.WriteLine("customers.GetType(): " + customers.GetType());

// customers.Add(new Customer { Name = "John Doe", Age = 30 });
// _context.SaveChanges();

// Console.WriteLine($"Customers Count: {customers.Count()}");

// customers.Add(new Customer { Name = "Danny Lee", Age = 30 });
// _context.SaveChanges();

// Because DbSet is not IList, index operator will not work
// var first = _context.Customers[0];

// var john = _context.Customers.FirstOrDefault(c => c.Name == "John Doe");
// if (john != null) john.Age = 31;

_context.SaveChanges();

foreach (var customer in customers)
{
    Console.WriteLine($"Id: {customer.CustomerId} Customer: {customer.Name}, Email: {customer.Email}");
}

class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDB;Integrated Security=True;TrustServerCertificate=True;");
    }
}

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Product { get; set; }

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // ✅ ONLY ADDITION (REQUIRED FOR BUILD)
    // [NotMapped]
    // public int Age { get; set; }
}


//My Code
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.SqlServer;

// using var _context = new CrmContext();

// var Users = _context.Users
//     .Where(e => e.Age > 20)
//     .ToList();

// // Users.Add(new User { Name = "John Doe", Age = 30 });
// // _context.SaveChanges();

// foreach (var user in Users)
// {
//     Console.WriteLine($"Id: {user.Id} User: {user.Name}, Age: {user.Age}");
// }

// class CrmContext : DbContext
// {
//     // public DbSet<Customer> Customers { get; set; }
//     public DbSet<User> Users { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDB;Integrated Security=True;TrustServerCertificate=True;");
//         // optionsBuilder.UseMySQL("YourConnectionStringHere");
//         // optionsBuilder.UsePostgreql("YourConnectionStringHere");
//     }
// }

// class User
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public int Age { get; set; }

// }