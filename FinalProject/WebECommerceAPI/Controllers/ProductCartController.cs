using FinalProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Http.Cors;

namespace WebECommerceAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductCartController : ApiController
    {
        ProductCartService productCartService = new ProductCartService();

        [HttpGet]
        [Route("api/productCart/{cartkey}/{key}")]
        public HttpResponseMessage GetInfo(string cartkey, string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            CartService cartManager = new CartService();
            int cartIndex = cartManager.getIndexByKey(cartkey);
            if (cartIndex != -1)
            {
                productCartService.setCart(cartManager.Read()[cartIndex]);
                int index = productCartService.getIndexByKey(key);
                if (index != -1)
                {
                    status = HttpStatusCode.OK;
                    ProductCart user = productCartService.Read()[index];
                    responseMessageJSON = JsonConvert.SerializeObject(user);
                }
                else
                {
                    status = HttpStatusCode.NotFound;
                    responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("ProductCart with id = {0} was not found", key) });
                }
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("Cart with id = {0} was not found", cartkey) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json"); ;
            return response;
        }

        [HttpGet]
        [Route("api/productCart/{cartkey}")]
        public HttpResponseMessage GetInfo2(string cartkey)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            CartService cartManager = new CartService();
            int cartIndex = cartManager.getIndexByKey(cartkey);
            if (cartIndex != -1)
            {
                status = HttpStatusCode.OK;
                productCartService.setCart(cartManager.Read()[cartIndex]);
                List<ProductCart> productCarts = productCartService.Read();
                responseMessageJSON = JsonConvert.SerializeObject(productCarts, Formatting.Indented);
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("Cart with id = {0} was not found", cartkey) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/productCart/{cartkey}")]
        public HttpResponseMessage PostInfo(string cartkey, HttpRequestMessage request)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            CartService cartManager = new CartService();
            int cartIndex = cartManager.getIndexByKey(cartkey);
            if (cartIndex != -1)
            {
                productCartService.setCart(cartManager.Read()[cartIndex]);
                try
                {
                    string content = request.Content.ReadAsStringAsync().Result;
                    ProductCart newProductCart = JsonConvert.DeserializeObject<ProductCart>(content);
                    if (productCartService.Create(newProductCart))
                    {
                        status = HttpStatusCode.Created;
                        responseMessage = "Product cart was created successfully";
                    }
                    else
                    {
                        status = HttpStatusCode.Conflict;
                        responseMessage = "Failed to create product cart";
                    }
                }
                catch (Exception e)
                {
                    status = HttpStatusCode.BadRequest;
                    responseMessage = "Couldn't convert data to ProductCart object";

                }
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessage = string.Format("Cart with id = {0} was not found", cartkey);
            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        [Route("api/productCart/{cartkey}/{id}")]
        public HttpResponseMessage UpdateInfo(string cartkey, string id, HttpRequestMessage request)
        {
            
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            CartService cartManager = new CartService();
            int cartIndex = cartManager.getIndexByKey(cartkey);
            if (cartIndex != -1)
            {
                productCartService.setCart(cartManager.Read()[cartIndex]);
                try
                {
                    string content = request.Content.ReadAsStringAsync().Result;
                    ProductCart newProductCart = JsonConvert.DeserializeObject<ProductCart>(content);
                    if (productCartService.Update(id, newProductCart))
                    {
                        status = HttpStatusCode.Created;
                        responseMessage = "ProductCart was updated successfully";
                    }
                    else
                    {
                        status = HttpStatusCode.Conflict;
                        responseMessage = "Failed to update product cart";
                    }
                }
                catch (Exception e)
                {
                    status = HttpStatusCode.BadRequest;
                    responseMessage = "Couldn't convert data to ProductCart object";

                }
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessage = string.Format("Cart with id = {0} was not found", cartkey);
            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpDelete]
        [Route("api/productCart/{cartkey}/{key}")]
        public HttpResponseMessage DeleteInfo(string cartkey, string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            CartService cartManager = new CartService();
            int cartIndex = cartManager.getIndexByKey(cartkey);
            if (cartIndex != -1)
            {
                productCartService.setCart(cartManager.Read()[cartIndex]);
                if (productCartService.Delete(key))
                {
                    status = HttpStatusCode.OK;
                    responseMessage = "ProductCart was deleted successfully";
                }
                else
                {
                    status = HttpStatusCode.BadRequest;
                    responseMessage = "ProductCart does not exist";
                }
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessage = string.Format("Cart with id = {0} was not found", cartkey);
            } 
            response = Request.CreateResponse(status);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }
    }
}