using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IProduct
    {
        //Expose the functions required
        Task<Product> Addproduct(int ProductId, string ProductName, int Quantity, int Price);
        Task<Product> Getprod(string ProductName);
        Task<Product> UpdateProd(string ProductName, Product prod);
        Task<Product> DeleteProd(string ProductName);
        Task<List<Product>> GetAllProducts();
        //Task Adduser(string username, string emailAddress, string password, int authLevelId);
    }
}
