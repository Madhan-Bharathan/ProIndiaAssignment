using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;


namespace DataAccess.DataContext
{
    public class DatabaseContext : DbContext //DbContext is a built in class that helps us to establish connection to DB
    {
        public class OptionsBuild // Class within the databasecontext
        {
            public OptionsBuild() //creating a constructor to fetch the connection strings
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; } // Establishes connection to DB by fetching details from appconfig file
            public DbContextOptions<DatabaseContext> dbOptions { get; set; } // Tells what database to use
            private AppConfiguration settings { get; set; } // intiating appconfiguration variable which obtains the connection strings
        }
        public static OptionsBuild ops = new OptionsBuild(); //Optionsbuild method should be called from anywhere within the dataaccess layer so declaring it as a static variable


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { } //db constructor for the entire class, we will use the dbset references to the entities
        // we need to tell entities which databasecontext to use
        public DbSet<Product> Products { get; set; } // creates the Products table
        public DbSet<Order> Orders { get; set; }

    }
}
