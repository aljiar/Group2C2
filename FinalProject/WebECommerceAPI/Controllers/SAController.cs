using FinalProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebECommerceAPI.Controllers
{
    public class SAController : ApiController , IController
    {
        ShippingAddressService saS = new ShippingAddressService();


        [HttpDelete]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage res;
            HttpStatusCode estado;
            string responseMessage;
            if (saS.Delete(key))
            {
                estado = HttpStatusCode.OK;
                responseMessage = "Successfull";
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
            string Sajson = JsonConvert.SerializeObject(saS.Read(), Formatting.Indented);
            var res = Request.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent(Sajson, Encoding.UTF8, "application/json");
            return res;
        }



        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage objeto)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage res;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                ShippingAddres newSA = JsonConvert.DeserializeObject<ShippingAddres>(content);
                if (saS.Create(newSA))
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
                responseMessage = "Couldn't convert data to User object";

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
                ShippingAddress newSA = JsonConvert.DeserializeObject<ShippingAddress>(content);
                if (saS.Update(id, newSA))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "User was updated successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to update user";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to User object";

            }
            res = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            res.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return res;
        }



    }
}