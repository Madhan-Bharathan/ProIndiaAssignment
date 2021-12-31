using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.OrderLogic
{
    public class OrderLogic
    {
        private IOrder _order = new DataAccess.Functions.OrderFunctions(); // interface instanatiation
        //Add a new user
        public async Task<Boolean> CreateNewOrder(int OrderId, string OrderName, int Quantity, int Price, int ProductRefId)
        {
            try
            {
                var result = await _order.Addorder(OrderId, OrderName, Quantity, Price, ProductRefId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ActionResult<Order>> UpdateOrder(string OrderName, Order ord)
        {
            try
            {
                var res = await _order.UpdateOrder(OrderName, ord);
                return res;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //Get all users
        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = await _order.GetAllOrders();
            return orders;
        }
    }
}
