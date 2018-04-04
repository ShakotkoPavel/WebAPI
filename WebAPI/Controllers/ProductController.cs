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
        [Route("GetProductById/{productId:int}")]
        public IHttpActionResult GetProductById(int productId)
        {
            return Json(repository.GetProductById(productId));
        }

        // POST: api/Product
        [HttpPost]
        [Route("AddProductToCart/{productId}/{messengerID}")]
        public HttpResponseMessage AddProductToCart(int productId, string messengerID = "1234")
        {
            repository.AddProductToCart(productId, messengerID);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Product/5
        [HttpDelete]
        [Route("BuyProducts/{messengerID}")]
        public HttpResponseMessage BuyProducts(string messengerId)
        {
            repository.BuyProducts(messengerId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
