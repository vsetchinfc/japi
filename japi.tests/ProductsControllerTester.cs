using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

using JApi.DAL;
using JApi.Models;
using JApi.Controllers;

namespace JApi.Tests
{
    public class ProductsControllerTester
    {
        private IRepository<Product> productRepository = null;

        public ProductsControllerTester()
        {
            productRepository = new ProductRepositoryTestData();
        }

        [Fact]
        public void TestPost()
        {
            ProductsController productController = new ProductsController(productRepository);
            Product prod5 = new Product() { Id = "5", Description = "Product 5", Model = "Model 5", Brand = "Brand 5" };
            var createdResponse = productController.Post(prod5);
 
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void TestPostExistingProduct()
        {
            ProductsController productController = new ProductsController(productRepository);
            Product prod5 = new Product() { Id = "1", Description = "Product 1", Model = "Model 1", Brand = "Brand 1" };
            var createdResponse = productController.Post(prod5);
 
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void TestGet()
        {
            ProductsController productController = new ProductsController(productRepository);

            var okResponse = productController.Get();

            Assert.IsType<OkObjectResult>(okResponse);
        }
    }
}
