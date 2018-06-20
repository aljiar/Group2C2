using FinalProject;
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
    public class ProductController : ApiController, IController
    {
        StoreManager storeService = new StoreManager();

        string schemaJson = @"{
                'description' : 'A Store',
                'type' : 'object',
                'properties' : {
                                    'Name' : {'type' : 'string', 'required' : true},
                                    'Line1' : {'type' : 'string', 'required' : true},
                                    'Line2' : {'type' : 'string', 'required' : true},
                                    'Phone' : {'type' : 'number', 'required' : true}
                                },
                  'additionalProperties': false
            }";



        [HttpGet]
        public HttpResponseMessage GetInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            List<Store> stores = storeService.Read();
            int index = stores.FindIndex(x => x.Name == id);

            if (index != -1)
            {
                Store store = stores[index];
                string storeJSON = JsonConvert.SerializeObject(store, Formatting.Indented);
                response.Content = new StringContent(storeJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error looking for a store with the specified ID.\" }", Encoding.UTF8, "application/json");
            }

            return response;
        }


        [HttpGet]
        public HttpResponseMessage GetInfo2()
        {
            string storeJSON = JsonConvert.SerializeObject(storeService.Read(), Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(storeJSON, Encoding.UTF8, "application/json");

            return response;
        }



        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            JSchema schema = JSchema.Parse(schemaJson);
            JObject store = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);
            IList<string> errorMessages;
            bool valid = store.IsValid(schema, out errorMessages);
            
            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"Error inserting a new store.\", \"Details\": \"" + errorMessages + "\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                bool created = false;
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Store storeJSON = JsonConvert.DeserializeObject<Store>(objeto.Content.ReadAsStringAsync().Result);
                created = storeService.Create(storeJSON);

                if(created == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("{ \"Error\": \"There was an error while creating a new store.\" }", Encoding.UTF8, "application/json");
                }
            }

            return response;
        }



        [HttpPut]
        public HttpResponseMessage UpdateInfo(string id, HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            JSchema schema = JSchema.Parse(schemaJson);
            JObject store = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);
            IList<string> errorMessages;
            bool valid = store.IsValid(schema, out errorMessages);

            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error updating the store with the specified ID.\", \"Details\": \"" + errorMessages + "\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                bool updated = false;
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Store storeJSON = JsonConvert.DeserializeObject<Store>(objeto.Content.ReadAsStringAsync().Result);
                updated = storeService.Update(id, storeJSON);

                if (updated == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("{ \"Error\": \"There was an error updating the store with the specified ID.\" }", Encoding.UTF8, "application/json");
                }
            }

            return response;
        }



        [HttpDelete]
        public HttpResponseMessage DeleteInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            bool deleted;

            deleted = storeService.Delete(id);
                
            if (deleted == true)
            {
                response.Content = new StringContent("{ \"Deleted\": \"The Store was successfully deleted.\"}", Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error looking for a store with the specified ID.\" }", Encoding.UTF8, "application/json");
            }

            return response;
        }

    }
}