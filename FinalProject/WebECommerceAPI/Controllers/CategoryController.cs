using FinalProject;
using FinalProject.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class CategoryController : ApiController, IController
    {
        CategoryService categoryService = new CategoryService();

        [HttpGet]
        [Route("api/category/{key}")]
        public HttpResponseMessage GetInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessageJSON;
            int index = categoryService.getIndexByKey(key);
            if (index != -1)
            {
                status = HttpStatusCode.OK;
                Category category = categoryService.Read()[index];
                responseMessageJSON = JsonConvert.SerializeObject(category);
            }
            else
            {
                status = HttpStatusCode.NotFound;
                responseMessageJSON = JsonConvert.SerializeObject(new { message = string.Format("Category with id = {0} was not found", key) });
            }
            response = Request.CreateResponse(status);
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json"); ;
            return response;
        }

        [HttpGet]
        [Route("api/category")]
        public HttpResponseMessage GetInfo2()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            List<Category> categories = categoryService.Read();
            string categoriesJSON = JsonConvert.SerializeObject(categories, Formatting.Indented);
            response.Content = new StringContent(categoriesJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/category")]
        public HttpResponseMessage PostInfo(HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                Category newCategory = JsonConvert.DeserializeObject<Category>(content);
                if (categoryService.Create(newCategory))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Category was created successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to create category";
                }
            }
            catch (Exception e)
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Couldn't convert data to Category object";

            }
            response = Request.CreateResponse(status);
            string responseContentJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseContentJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPut]
        [Route("api/category/{key}")]
        public HttpResponseMessage UpdateInfo(string key, HttpRequestMessage request)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            try
            {
                Category newCategory = JsonConvert.DeserializeObject<Category>(content);
                if (categoryService.Update(key, newCategory))
                {
                    status = HttpStatusCode.Created;
                    responseMessage = "Category was updated successfully";
                }
                else
                {
                    status = HttpStatusCode.Conflict;
                    responseMessage = "Failed to update category";
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
        [Route("api/category/{key}")]
        public HttpResponseMessage DeleteInfo(string key)
        {
            HttpResponseMessage response;
            HttpStatusCode status;
            string responseMessage;
            if (categoryService.Delete(key))
            {
                status = HttpStatusCode.OK;
                responseMessage = "Category was deleted successfully";
            }
            else
            {
                status = HttpStatusCode.BadRequest;
                responseMessage = "Category does not exist";
            }
            response = Request.CreateResponse(status);
            string responseMessageJSON = JsonConvert.SerializeObject(new { message = responseMessage });
            response.Content = new StringContent(responseMessageJSON, Encoding.UTF8, "application/json");
            return response;
        }

    }
}