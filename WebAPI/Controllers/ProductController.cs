using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Context.ProductRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository repository;

        public ProductController(IProductRepository rep)
        {
            repository = rep;
        }

        // GET: api/Product
        public IEnumerable<Category> GetAllCategories()
        {
            return repository.GetAllCategories();
        }

        public IEnumerable<Product> GetAllProductsByCategoryId(int categoryId)
        {
            return repository.GetAllProductsByCategoryId(categoryId);
        }

        // GET: api/Product/5
        public Product GetProductById(int id)
        {
            return repository.GetProductById(id);
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
