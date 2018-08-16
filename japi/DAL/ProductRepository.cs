using System;
using System.Collections.Generic;
using System.Linq;
using JApi.Models;

namespace JApi.DAL
{
    public class ProductRepository : IRepository<Product>, IDisposable
    {
        protected static Dictionary<string, Product> productsRepository = new Dictionary<string, Product>();

        public void Add(Product product)
        {
            if(string.IsNullOrEmpty(product.Description) 
                || string.IsNullOrEmpty(product.Model) 
                || string.IsNullOrEmpty(product.Brand))
            {
                throw new MissingFieldException("Required field Description, Model or Brand is missing.");
            }

            if(string.IsNullOrEmpty(product.Id))
            {
                product.Id = Guid.NewGuid().ToString();
            }
            
            if(!productsRepository.Keys.Contains(product.Id))
            {
                productsRepository.Add(product.Id, product);
            }
            else
            {
                throw new ArgumentException(string.Format("Product with id '{0}' already exists.", product.Id));
            }
        }

        public void Delete(string id)
        {
            if(productsRepository.Keys.Contains(id))
            {
                productsRepository.Remove(id);
            }
        }

        public void Dispose()
        {
            // productsRepository.Clear();
            // productsRepository = null;
        }

        public IEnumerable<Product> Get()
        {
            return productsRepository.Values;
        }

        public Product Get(string id)
        {
            Product product = null;

            if(productsRepository.Keys.Contains(id))
            {
                product = productsRepository[id];
            }

            return product;
        }

        public void Update(string id, Product product)
        {
            if(productsRepository.Keys.Contains(id))
            {
                productsRepository[product.Id] = product;
            }
        }
    }
}