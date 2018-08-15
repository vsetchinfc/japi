using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using JApi.DAL;
using JApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace JApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
// GET /products - Retrieves a list of products
// GET /products/12 - Retrieves a specific ticket
// POST /products - Creates a new product
// PUT /products/12 - Updates product #12
// DELETE /products/12 - Deletes product #12

        private IRepository<Product> _repository ;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Product> products = _repository.Get();

            if(products.Count() == 0)
            {
                return NotFound(); 
            }

            return Ok(products);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Product product = _repository.Get(id);

            if(product == null)
            {
                return NotFound(id);
            }

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            try
            {
                _repository.Add(product);
            }
            catch(ArgumentException)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict);
            }

            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Product product)
        {
            _repository.Update(id, product);

            //NotFound();
            
            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _repository.Delete(id);

            // NotFound();

            return Ok();
        }
    }
}
