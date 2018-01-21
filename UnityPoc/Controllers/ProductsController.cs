using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using UnityPoc.Models;

namespace UnityPoc.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ILogger _logger;
        public IProductsRepository ProductsRepository { get; }

        public ProductsController(
            ILogger logger,
            IProductsRepository productsRepository)
        {
            _logger = logger;
            ProductsRepository = productsRepository;
        }

        // GET: api/Products
        public IHttpActionResult Get()
        {
            var products = ProductsRepository.Get();
            _logger.Log(LogLevel.Info, "Get called.");
            return Ok(products);
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            throw new Exception("You messed up.");
            //return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
