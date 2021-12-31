using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrder
    {
        Task<Order> Addorder(int OrderId, string OrderName, int Quantity, int Price, int ProductRefId);
        Task<Order> UpdateOrder(string OrderName, Order ord);
        Task<List<Order>> GetAllOrders();
    }
}
