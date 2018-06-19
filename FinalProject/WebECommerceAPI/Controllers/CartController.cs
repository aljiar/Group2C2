using FinalProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

namespace WebECommerceAPI.Controllers
{
    public class CartController : ApiController, IController
    {
        CartManager cartService = new CartManager();

        [HttpGet]
        public HttpResponseMessage GetInfo(string id)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            int index = cartService.getIndexByKey(id);
            if (index != -1)
            {
                status = HttpStatusCode.OK;
                Cart cart = cartService.Read()[index];
                responseMessageJSON = JsonConvert.SerializeObject(cart);
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("Cart with id = {0} was not found", id) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json"); ;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetInfo2()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            List<Cart> carts = cartService.Read();
            string cartsJSON = JsonConvert.SerializeObject(carts, Formatting.Indented);
            response.Content = new StringContent(cartsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                Cart newCart = JsonConvert.DeserializeObject<Cart>(content);
                if (cartService.Create(newCart))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Cart was created successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to create cart";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Cart object";

            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateInfo(string id, HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                Cart newCart = JsonConvert.DeserializeObject<Cart>(content);
                if (cartService.Update(id, newCart))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Cart was updated successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to update cart";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Cart object";

            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpDelete]
        [Route("api/cart/{key}")]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            if (cartService.Delete(key))
            {
                status = HttpStatusCode.OK;
                responseMessage = "Cart was deleted successfully";
            }
            else
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Cart does not exist";
            }
            response = Request.CreateResponse(status);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }
    }
}