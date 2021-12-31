using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;

// to establish connection from entities to databasecontext
namespace DataAccess.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args) //entities framework will look at this class for database connection details
        { // creates tables based on entities layers
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new DatabaseContext(opsBuilder.Options); // returning what to use to the entites framework for db connections
        }
    }
}
