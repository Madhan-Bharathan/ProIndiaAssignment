using DataAccess.DataContext;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


// creating two functions to add product and to retrieve products from db
namespace DataAccess.Functions
{
    public class UserFunctions : IProduct
    {
        //Add a new user
        
        public async Task<Product> Addproduct(int ProductId, string ProductName, int Quantity, int Price) // IProduct helps to connect to interface when this statement is initialized 
        {
           
            Product newProduct = new Product //creating new product object and passing the details
            {
                ProductId = ProductId,
                Quantity = Quantity,
                ProductName = ProductName,
                Price = Price
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions)) //initiating db context 
            {
                await context.Products.AddAsync(newProduct);
                await context.SaveChangesAsync(); // save changes to db, similar to commit command
            }
            return newProduct; // after committing we are returning the new user
        }
        public async Task<Product> Getprod(string ProductName)//, int Quantity, string Availability)
        {
            Product res = new Product
            {
                ProductName = ProductName
            };

            //List<Product> products = new List<Product>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                res = await context.Products.FirstAsync(u => u.ProductName == ProductName);
            }
            return res;
        }

        public async Task<Product> DeleteProd(string ProductName)//, int Quantity, string Availability)
        {
            Product res = new Product
            {
                ProductName = ProductName
            };

            //List<Product> products = new List<Product>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                res = await context.Products.FirstAsync(u => u.ProductName == ProductName);
                context.Products.Remove(res);
                await context.SaveChangesAsync();
            }
            return res;
        }

        public async Task<Product> UpdateProd(string ProductName, Product prod)//, int Quantity, string Availability)
        {
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                var entity = await context.Products.FirstAsync((u) => u.ProductName == ProductName);
                entity.ProductId = prod.ProductId;
                entity.Price = prod.Price;
                entity.Quantity = prod.Quantity;
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                products = await context.Products.ToListAsync();
            }
            return products;

        }
    }
}