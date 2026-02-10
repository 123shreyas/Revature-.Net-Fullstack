using System;
using System.Collections.Generic;
using System.Linq;

namespace DeligateDemo
{
    public class LinqDemo
    {
        // Models
        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; } = string.Empty;
        }

        public class Order
        {
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public decimal OrderAmount { get; set; }
        }

        // Entry method for this demo
        public void Run()
        {
            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice" },
                new Customer { CustomerId = 2, CustomerName = "Bob" },
                new Customer { CustomerId = 3, CustomerName = "Charlie" }
            };

            var orders = new List<Order>
            {
                new Order { OrderId = 101, CustomerId = 1, OrderAmount = 2500 },
                new Order { OrderId = 102, CustomerId = 1, OrderAmount = 1500 },
                new Order { OrderId = 103, CustomerId = 2, OrderAmount = 3000 },
                new Order { OrderId = 104, CustomerId = 2, OrderAmount = 2000 },
                new Order { OrderId = 105, CustomerId = 2, OrderAmount = 1000 }
            };

            // LINQ Query Syntax
            //  var customerOrderSummary =
            //     from c in customers
            //     join o in orders on c.CustomerId equals o.CustomerId
            //     group o by new { c.CustomerId, c.CustomerName } into g
            //     select new
            //     {
            //         CustomerId = g.Key.CustomerId,
            //         CustomerName = g.Key.CustomerName,
            //         OrderCount = g.Count(),
            //         TotalOrderValue = g.Sum(x => x.OrderAmount),
            //         Orders = g.ToList()
            //     };

            // LINQ Method Syntax
            var customerOrderSummary = customers
     .Join(
         orders,
         c => c.CustomerId,
         o => o.CustomerId,
         (c, o) => new { c, o }
     )
     .GroupBy(x => new { x.c.CustomerId, x.c.CustomerName })
     .Select(g => new
     {
         g.Key.CustomerId,
         g.Key.CustomerName,
         OrderCount = g.Count(),
         TotalOrderValue = g.Sum(x => x.o.OrderAmount),
         Orders = g.Select(x => x.o).ToList()
     });

            // Displaying the results
            foreach (var item in customerOrderSummary)
            {
                Console.WriteLine($"Customer: {item.CustomerName}");
                Console.WriteLine($"Total Orders: {item.OrderCount}");
                Console.WriteLine($"Total Order Value: {item.TotalOrderValue}");

                Console.WriteLine("Orders:");
                foreach (var order in item.Orders)
                {
                    Console.WriteLine($"  OrderId: {order.OrderId}, Amount: {order.OrderAmount}");
                }

                Console.WriteLine();
            }
        }
    }
}
