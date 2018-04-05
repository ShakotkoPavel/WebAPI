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
using System.Text;

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

        [Route("GetAllCategories")]
        public HttpResponseMessage GetAllCategories()
        {
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, repository.GetAllCategories());
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return httpResponseMessage;
        }

        [Route("GetAllProductsByCategoryId/{categoryId:int}")]
        public IHttpActionResult GetAllProductsByCategoryId(int categoryId)
        {
            return Json(repository.GetAllProductsByCategoryId(categoryId));
        }

        [Route("GetProductById/{productId:int}")]
        public IHttpActionResult GetProductById(int productId)
        {
            return Json(repository.GetProductById(productId));
        }

        [HttpPost]
        [Route("AddProductToCart/{productId}/{messengerID}")]
        public HttpResponseMessage AddProductToCart(int productId, string messengerID = "1234")
        {
            repository.AddProductToCart(productId, messengerID);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("BuyProducts/{messengerID}")]
        public HttpResponseMessage BuyProducts(string messengerId)
        {
            if(repository.CheckBalance(messengerId))
            {
                var account = repository.GetAccount(messengerId);
                repository.BuyProducts(account);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
