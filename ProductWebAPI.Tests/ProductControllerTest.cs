using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;
using System.Threading.Tasks;
using XAct.Messages;
using Xunit;
using ProductWebAPI.API;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Interfaces;
using AutoFixture;
using FakeItEasy;
using System.Linq;
using System.Collections.Generic;

namespace ProductWebAPI.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void canChangeProductName()
        {
            var prod = new ProductViewModel
            {
                ProductName = "Mixie",
                ProductId = 5,
                Price = 1000,
                Quantity = 1
            };

            prod.ProductName = "New Name";

            Assert.Equal("New Name",prod.ProductName);
        }

        [Fact]
        public void canChangeOrderQuantity()
        {
            var prod = new OrderViewModel
            {
                OrderName = "Mixie",
                OrderId = 5,
                Price = 1000,
                Quantity = 1
            };

            prod.Quantity = 99;

            Assert.Equal(99, prod.Quantity);
        }

        [Fact]
        public void canChangeOrderPrice()
        {
            var prod = new OrderViewModel
            {
                OrderName = "Mixie",
                OrderId = 5,
                Price = 1000,
                Quantity = 1
            };

            prod.Price = 99;

            Assert.Equal(99, prod.Price);
        }

        [Fact]
        public void canChangeProductPrice()
        {
            var prod = new OrderViewModel
            {
                OrderName = "Mixie",
                OrderId = 5,
                Price = 1000,
                Quantity = 1
            };

            prod.Price = 99;

            Assert.Equal(99, prod.Price);
        }

        [Fact]
        public void canChangeProductQuantity()
        {
            var prod = new OrderViewModel
            {
                OrderName = "Mixie",
                OrderId = 5,
                Price = 1000,
                Quantity = 1
            };

            prod.Quantity = 99;

            Assert.Equal(99, prod.Quantity);
        }
    }
}
