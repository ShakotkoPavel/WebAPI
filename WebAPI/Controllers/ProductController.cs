using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Context.ProductRepository;
using WebAPI.Models;
using Newtonsoft.Json;
using System.Web.Http.Results;

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
        public IHttpActionResult GetAllCategories()
        {
            return Json(repository.GetAllCategories());
        }

        [Route("GetAllProductsByCategoryId/{categoryId:int}")]
        public IHttpActionResult GetAllProductsByCategoryId(int categoryId)
        {
            //if(repository.GetAllCategories().Count() > 0)
                return Json(repository.GetAllProductsByCategoryId(categoryId));
            //return 
        }

        // GET: api/Product/5
        [Route("GetProductById/{id:int}")]
        public IHttpActionResult GetProductById(int id)
        {
            return Json(repository.GetProductById(id));
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
