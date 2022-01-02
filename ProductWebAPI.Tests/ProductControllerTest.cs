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
        //Fakes
        private readonly IProduct _productService;

        //Dummy Data Generator
        private readonly Fixture _fixture;

        //System under test
        private readonly APIProduct_Controller _sut;
        public ProductControllerTest()
        {
            _productService = A.Fake<IProduct>();
            _sut = new APIProduct_Controller(_productService);

            _fixture = new Fixture();
        }


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