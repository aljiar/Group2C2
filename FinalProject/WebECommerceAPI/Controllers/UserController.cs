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
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class UserController : ApiController, IController
    {
        UserManager userService = new UserManager();

        [HttpGet]
        [Route("api/user/{key}")]
        public HttpResponseMessage GetInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            int index = userService.getIndexByKey(key);
            if (index != -1)
            {
                status = HttpStatusCode.OK;
                User user = userService.Read()[index];
                responseMessageJSON = JsonConvert.SerializeObject(user);
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("User with id = {0} was not found", key) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json"); ;
            return response;
        }

        [HttpGet]
        [Route("api/user")]
        public HttpResponseMessage GetInfo2()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            List<User> users = userService.Read();
            string usersJSON = JsonConvert.SerializeObject(users, Formatting.Indented);
            response.Content = new StringContent(usersJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/user")]
        public HttpResponseMessage PostInfo(HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                User newUser = JsonConvert.DeserializeObject<User>(content);
                if (userService.Create(newUser))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "User was created successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to create user";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to User object";

            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        [Route("api/user/{key}")]
        public HttpResponseMessage UpdateInfo(string key, HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                User newUser = JsonConvert.DeserializeObject<User>(content);
                if (userService.Update(key, newUser))
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
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpDelete]
        [Route("api/user/{key}")]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            if (userService.Delete(key))
            {
                status = HttpStatusCode.OK;
                responseMessage = "User was deleted successfully";
            }
            else
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "User does not exist";
            }
            response = Request.CreateResponse(status);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage});
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }
    }
}