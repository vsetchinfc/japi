using System;
using System.Collections.Generic;
using System.Linq;

using JApi.DAL;
using JApi.Models;

namespace JApi.Tests
{
    public class ProductRepositoryTestData : ProductRepository, IRepository<Product>, IDisposable
    {
        private Dictionary<string, Product> productsRepository = new Dictionary<string, Product>();

        public ProductRepositoryTestData()
        {
            Product prod1 = new Product() { Id = "1", Description = "Product 1", Model = "Model 1", Brand = "Brand 1" };
            productsRepository.Add(prod1.Id, prod1);

            Product prod2 = new Product() { Id = "2", Description = "Product 2", Model = "Model 2", Brand = "Brand 2" };
            productsRepository.Add(prod2.Id, prod2);

            Product prod3 = new Product() { Id = "3", Description = "Product 3", Model = "Model 3", Brand = "Brand 3" };
            productsRepository.Add(prod3.Id, prod3);
        }
    }
}