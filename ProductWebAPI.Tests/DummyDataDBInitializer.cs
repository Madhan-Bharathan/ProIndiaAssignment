using DataAccess.DataContext;
using DataAccess.Entities;
using ProductWebAPI.Models;
using System;

namespace ProductWebAPI.Tests
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(DatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            context.Products.AddRange(
                new Product() { ProductName = "Fan", Quantity = 10, Price = 890 },
                new Product() { ProductName = "Light", Quantity = 14, Price = 180 }
            );
            context.SaveChanges();
        }
    }
}