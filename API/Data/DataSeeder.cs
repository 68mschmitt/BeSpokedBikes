using System;
using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Data
{
    public class DataSeeder
    {
        public static void SeedCustomers(BeSpokedDataContext context)
        {
            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer { FirstName = "Iron", LastName = "Man", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Tony", LastName = "Stark", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Bruce", LastName = "Banner", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Nick", LastName = "Fury", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Spider", LastName = "Man", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Thor", LastName = "Odinson", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Maria", LastName = "Hill", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Black", LastName = "Widow", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Steve", LastName = "Rodgers", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow },
                    new Customer { FirstName = "Hawk", LastName = "Eye", Address = "123 Somewhere", Phone = "1234567890", StartDate = DateTime.UtcNow }
                };
                context.AddRange(customers);
                context.SaveChanges();
            }
        }
        public static void SeedProducts(BeSpokedDataContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "1 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "2 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "3 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "4 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "5 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "6 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "7 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "8 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "9 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 },
                    new Product { Name = "10 Speed Bike", Manufacturer = "Amazon", Style = "Cool", PurchasePrice = 50, SalePrice = 100, QuantityOnHand = 10, CommissionPercentage = 3 }
                };
                context.AddRange(products);
                context.SaveChanges();
            }
        }

        public static void SeedSalesPeople(BeSpokedDataContext context)
        {
            if (!context.SalesPeople.Any())
            {
                var salesPeople = new List<SalesPerson>
                {
                    new SalesPerson { FirstName = "Bat", LastName = "Man", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "The", LastName = "Joker", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "Super", LastName = "Man", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "Dead", LastName = "Shot", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "The", LastName = "Robin", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "Bat", LastName = "Girl", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "The", LastName = "Flash", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "Wonder", LastName = "Woman", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "Aqua", LastName = "Man", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null },
                    new SalesPerson { FirstName = "Martian", LastName = "Manhunter", Address = "456 Somewhere", Phone = "0987654321", Manager = "Alfred", StartDate = DateTime.UtcNow, TerminationDate = null }
                };
                context.AddRange(salesPeople);
                context.SaveChanges();
            }
        }
    }
}