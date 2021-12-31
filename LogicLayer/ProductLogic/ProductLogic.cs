using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LogicLayer.ProductLogic
{
    public class ProductLogic
    {
        private IProduct _product = new DataAccess.Functions.UserFunctions(); // interface instanatiation
        //Add a new user
        public async Task<Boolean> CreateNewProduct(int ProductId, string ProductName, int Quantity, int Price)
        {
            try
            {
                var result = await _product.Addproduct(ProductId, ProductName, Quantity, Price);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ActionResult<Product>> GetProdByName(string ProductName)
        {
            try
            {
                var res = await _product.Getprod(ProductName);               
                return res;                               
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        public async Task<ActionResult<Product>> DeleteProd(string ProductName)
        {
            try
            {
                var res = await _product.DeleteProd(ProductName);
                return res;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult<Product>> UpdateProd(string ProductName, Product prod)
        {
            try
            {
                var res = await _product.UpdateProd(ProductName, prod);
                return res;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //Get all users
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = await _product.GetAllProducts();
            return products;
        }

        

    }
}
