using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ProductWebAPI.Models;

namespace ProductWebAPI.Tests
{
    public static class DbContextMocker
    {
        public static DatabaseContext GetProductDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new DatabaseContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
