using DataAccess.Entities;
using LogicLayer.OrderLogic;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;

namespace ProductWebAPI.API
{
    [Route("api/v2/order/")]
    [ApiController]
    public class APIOrder_Controller : ControllerBase
    {
        private OrderLogic orderLogic = new OrderLogic();

            // add user using post method
            [Route("add")]
            [HttpGet]
            public async Task<Boolean> Addorder(int OrderId, string OrderName, int Quantity, int Price, int ProductRefId)
            {
                bool result = await orderLogic.CreateNewOrder(OrderId, OrderName, Quantity, Price, ProductRefId);
                return result;
            }

            [Route("updateorder/{OrderName}")]
            [HttpPut("{OrderName}")]

            public async Task<ActionResult<Order>> UpdateProd(string OrderName, Order ord)
            {
                try
                {
                    var res = await orderLogic.UpdateOrder(OrderName, ord);
                    return res;
                }
                catch (Exception)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }


            [Route("allorders")]
            [HttpGet]
            public async Task<List<OrderViewModel>> GetAllOrders()
            {
                List<OrderViewModel> orderList = new List<OrderViewModel>();
                var orders = await orderLogic.GetAllOrders();
                if (orders.Count > 0)

                {
                    foreach (var order in orders)
                    {
                        OrderViewModel currentorder = new OrderViewModel
                        {

                            Quantity = order.Quantity,
                            OrderName = order.OrderName,
                            OrderId = order.OrderId,
                            Price = order.Price

                        };
                        orderList.Add(currentorder);
                    }
                }
                return orderList;
            }

        
    }
}
