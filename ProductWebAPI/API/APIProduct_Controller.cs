using DataAccess.Entities;
using DataAccess.Interfaces;
using LogicLayer.ProductLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;
using System.Dynamic;


namespace ProductWebAPI.API
{
    [Route("api/v1/product/")]
    [ApiController]
    public class UserAPI_Controller : ControllerBase
    {
        private ProductLogic productLogic = new ProductLogic();

        // add user using post method
        [Route("add")]
        [HttpGet]
        public async Task<Boolean> Addproduct(int ProductId, string ProductName, int Quantity, int Price)
        {
                bool result = await productLogic.CreateNewProduct(ProductId, ProductName,Quantity,Price);
                Order order = new Order();
                return result;
         }

        [Route("Getprod/{ProductName}")]
        [HttpGet("{ProductName}")]
        
        public async Task<ActionResult<Product>> Getprod(string ProductName)
        {
            try
            {
                //bool result = await productLogic.GetProdByName(ProductName);
                //return result;
                var item = await productLogic.GetProdByName(ProductName);
               // Console.WriteLine(item);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("deleteprod/{ProductName}")]
        [HttpDelete("{ProductName}")]

        public async Task<ActionResult<Product>> DeleteProd(string ProductName)
        {
            try
            {
                var res = await productLogic.DeleteProd(ProductName);
                if(res == null)
                {
                    return NotFound();
                }
                return res;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("updateprod/{ProductName}")]
        [HttpGet("{ProductName}")]

        public async Task<ActionResult<Product>> UpdateProd(string ProductName, Product prod)
        {
            try
            {
                var res = await productLogic.UpdateProd(ProductName,prod);
                return res;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }



        [Route("all")]
        [HttpGet]
        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var products = await productLogic.GetAllProducts();
            if (products.Count > 0)

            {
                foreach (var product in products)
                {
                    ProductViewModel currentProduct = new ProductViewModel
                    {

                        Quantity = product.Quantity,
                        ProductName = product.ProductName,
                        ProductId = product.ProductId,
                        Price = product.Price

                    };
                    productList.Add(currentProduct);
                }
            }
            return productList;
        }
    }
}
