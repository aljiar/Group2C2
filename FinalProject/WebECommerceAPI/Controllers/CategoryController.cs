using FinalProject;
using FinalProject.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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
        CategoryService categoryServ = new CategoryService();

        string schemaJson = @"{
                'description' : 'A Category',
                'type' : 'object',
                'properties' : {
                                    'Name' : {'type' : 'string', 'required' : true},
                                    'Description' : {'type' : 'string', 'required' : true}
                                },
                  'additionalProperties': false
        }";


        [HttpGet]
        public HttpResponseMessage GetInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            List<Category> categories = categoryServ.Read();
            int index = categories.FindIndex(x => x.Name == id);

            if (index != -1)
            {
                Category category = categories[index];
                string productJSON = JsonConvert.SerializeObject(category, Formatting.Indented);
                response.Content = new StringContent(productJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error looking for a category with the specified ID.\" }", Encoding.UTF8, "application/json");
            }

            return response;
        }


        [HttpGet]
        public HttpResponseMessage GetInfo2()
        {
            string categoryJSON = JsonConvert.SerializeObject(categoryServ.Read(), Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(categoryJSON, Encoding.UTF8, "application/json");

            return response;
        }

        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            JSchema schema = JSchema.Parse(schemaJson);
            JObject category = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);
            IList<string> errorMessages;
            bool valid = category.IsValid(schema, out errorMessages);

            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"Error inserting a new category.\", \"Details\": \"" + errorMessages + "\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                bool created = false;
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Category categoryJSON = JsonConvert.DeserializeObject<Category>(objeto.Content.ReadAsStringAsync().Result);
                created = categoryServ.Create(categoryJSON);

                if (created == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("{ \"Error\": \"There was an error while creating a new category.\" }", Encoding.UTF8, "application/json");
                }
            }

            return response;
        }



        [HttpPut]
        public HttpResponseMessage UpdateInfo(string id, HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            JSchema schema = JSchema.Parse(schemaJson);
            JObject category = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);
            IList<string> errorMessages;
            bool valid = category.IsValid(schema, out errorMessages);

            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error updating the category with the specified Name.\", \"Details\": \"" + errorMessages + "\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                bool updated = false;
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Category categoryJSON = JsonConvert.DeserializeObject<Category>(objeto.Content.ReadAsStringAsync().Result);
                updated = categoryServ.Update(id, categoryJSON);

                if (updated == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("{ \"Error\": \"There was an error updating the category with the specified Name.\" }", Encoding.UTF8, "application/json");
                }
            }

            return response;
        }



        [HttpDelete]
        public HttpResponseMessage DeleteInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            bool deleted;

            deleted = categoryServ.Delete(id);

            if (deleted == true)
            {
                response.Content = new StringContent("{ \"Deleted\": \"The Category was successfully deleted.\"}", Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error looking for a category with the specified Name.\" }", Encoding.UTF8, "application/json");
            }

            return response;
        }

    }
}