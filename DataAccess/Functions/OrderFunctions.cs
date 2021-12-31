using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Functions
{
    public class OrderFunctions : IOrder
    {
        public async Task<Order> Addorder(int OrderId, string OrderName, int Quantity, int Price, int ProductRefId) // IProduct helps to connect to interface when this statement is initialized 
        {
            //if (Quantity > 0 )
            //{
               // Product quanProduct = new Product
                //{
                   // ProductId = prod.ProductId,
                    //ProductName = prod.ProductName,
                   // Quantity = prod.Quantity - Quantity,
                   // Price = prod.Price,
               // };
                //using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions)) //initiating db context 
                //{
                //    await context.Products.AddAsync(quanProduct);
                //    await context.SaveChangesAsync(); // save changes to db, similar to commit command
                //}
           // }
            Order newOrder = new Order //creating new product object and passing the details
            {
                OrderId = OrderId,
                Quantity = Quantity,
                OrderName = OrderName,
                Price = Price,
                ProductRefId = ProductRefId
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions)) //initiating db context 
            {
                await context.Orders.AddAsync(newOrder);
                await context.SaveChangesAsync(); // save changes to db, similar to commit command
            }
            return newOrder; // after committing we are returning the new user
        }

        public async Task<Order> UpdateOrder(string OrderName, Order ord)//, int Quantity, string Availability)
        {
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                var entity = await context.Orders.FirstAsync((u) => u.OrderName == OrderName);
                entity.OrderId = ord.OrderId;
                entity.Price = ord.Price;
                entity.Quantity = ord.Quantity;
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                orders = await context.Orders.ToListAsync();
            }
            return orders;

        }
    }
}
