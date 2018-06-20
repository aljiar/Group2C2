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
    class StoreController : ApiController, IController
    {
        StoreManager storeService = new StoreManager();

        [HttpGet]
        [Route("api/store/{key}")]
        public HttpResponseMessage GetInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            int index = storeService.getIndexByKey(key);
            if (index != -1)
            {
                status = HttpStatusCode.OK;
                Store store = storeService.Read()[index];
                responseMessageJSON = JsonConvert.SerializeObject(store);
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("Store with id = {0} was not found", key) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json"); ;
            return response;
        }

        [HttpGet]
        [Route("api/store")]
        public HttpResponseMessage GetInfo2()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            List<Store> stores = storeService.Read();
            string storesJSON = JsonConvert.SerializeObject(stores, Formatting.Indented);
            response.Content = new StringContent(storesJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/store")]
        public HttpResponseMessage PostInfo(HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                Store newStore = JsonConvert.DeserializeObject<Store>(content);
                if (storeService.Create(newStore))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Store was created successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to create store";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Store object";

            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        [Route("api/store/{key}")]
        public HttpResponseMessage UpdateInfo(string key, HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                Store newStore = JsonConvert.DeserializeObject<Store>(content);
                if (storeService.Update(key, newStore))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Store was updated successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to update store";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Store object";

            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpDelete]
        [Route("api/store/{key}")]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            if (storeService.Delete(key))
            {
                status = HttpStatusCode.OK;
                responseMessage = "Store was deleted successfully";
            }
            else
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Store does not exist";
            }
            response = Request.CreateResponse(status);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }
    }
}