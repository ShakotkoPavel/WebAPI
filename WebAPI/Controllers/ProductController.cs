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
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IProductRepository repository;

        public ProductController(IProductRepository rep)
        {
            repository = rep;
        }

        // GET: api/Product
        [Route("GetAllCategories")]
        public HttpResponseMessage GetAllCategories()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.GetAllCategories());
            return response;
        }

        [Route("GetAllProductsByCategoryId/{id:int}")]
        public IEnumerable<Product> GetAllProductsByCategoryId(int categoryId)
        {
            return repository.GetAllProductsByCategoryId(categoryId);
        }

        // GET: api/Product/5
        [Route("GetProductById/{id:int}")]
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
