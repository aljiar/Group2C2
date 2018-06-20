using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Http.Cors;
using FinalProject;
using Newtonsoft.Json;

namespace WebECommerceAPI.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class ShippingAddressController : ApiController
    {
        ShippingAddressManager shippingService = new ShippingAddressManager();


        [HttpDelete]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage res;
            HttpStatusCode estado;
            string responseMessage;
            if (shippingService.Delete(key))
            {
                estado = HttpStatusCode.OK;
                responseMessage = "Successful";
            }
            else
            {
                estado = HttpStatusCode.BadRequest;
                responseMessage = "Address not found";
            }
            res = Request.CreateResponse(estado);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            res.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetInfo2()
        {
            string Sajson = JsonConvert.SerializeObject(shippingService.Read(), Formatting.Indented);
            var res = Request.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent(Sajson, Encoding.UTF8, "application/json");
            return res;
        }



        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage res;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                ShippingAddress newShippingAddress = JsonConvert.DeserializeObject<ShippingAddress>(content);
                if (shippingService.Create(newShippingAddress))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Address was created successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to create";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Shipping address object";

            }
            res = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            res.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return res;


        }

        [HttpPut]
        public HttpResponseMessage UpdateInfo(string id, HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage res;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                ShippingAddress newShippingAddress = JsonConvert.DeserializeObject<ShippingAddress>(content);
                if (shippingService.Update(id, newShippingAddress))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Shipping address was updated successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to update shipping address";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Shipping address object";

            }
            res = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            res.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return res;
        }
    }
}