using FinalProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebECommerceAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductController : ApiController, IController
    {
        ProductService productService = new ProductService();

        [HttpGet]
        [Route("api/product/{key}")]
        public HttpResponseMessage GetInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            int index = productService.getIndexByKey(key);
            if (index != -1)
            {
                status = HttpStatusCode.OK;
                Product product = productService.Read()[index];
                responseMessageJSON = JsonConvert.SerializeObject(product);
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("Product with id = {0} was not found", key) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json"); ;
            return response;
        }

        [HttpGet]
        [Route("api/product")]
        public HttpResponseMessage GetInfo2()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            List<Product> products = productService.Read();
            string productsJSON = JsonConvert.SerializeObject(products, Formatting.Indented);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/product")]
        public HttpResponseMessage PostInfo(HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            try
            {
                Product newProduct = JsonConvert.DeserializeObject<Product>(content);
                if (productService.Create(newProduct))
                {
                    status = HttpStatusCode.Created;
                    responseMessageJSON = JsonConvert.SerializeObject(newProduct);
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessageJSON = JsonConvert.SerializeObject(new { message = "Failed to create product" });
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = "Couldn't convert data to Product object" });

            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        [Route("api/product/{key}")]
        public HttpResponseMessage UpdateInfo(string key, HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            try
            {
                Product newProduct = JsonConvert.DeserializeObject<Product>(content);
                if (productService.Update(key, newProduct))
                {
                    status = HttpStatusCode.Created;
                    responseMessageJSON = JsonConvert.SerializeObject(newProduct);
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessageJSON = JsonConvert.SerializeObject(new { message = "Failed to update product" });
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = "Couldn't convert data to Product object" });

            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpDelete]
        [Route("api/product/{key}")]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            if (productService.Delete(key))
            {
                status = HttpStatusCode.OK;
                responseMessage = "Product was deleted successfully";
            }
            else
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Product does not exist";
            }
            response = Request.CreateResponse(status);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }

    }
}