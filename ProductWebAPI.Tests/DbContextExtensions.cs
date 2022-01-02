using DataAccess.DataContext;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI.Tests
{
    public static class DbContextExtensions
    {
        public static void Seed(this DatabaseContext dbContext)
        {
            // Add entities for DbContext instance

            dbContext.Products.Add(new Product
            {
               ProductId = 1,
               ProductName = "Grinder",
               Price = 5000,
               Quantity = 1
            });
            dbContext.SaveChanges();
        }
    }
}
