using FinalProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebECommerceAPI.Controllers
{
    public class ProductController : ApiController, IController
    {
        ProductService prodServ = new ProductService();

        string schemaJson = @"{
                'description' : 'A Product',
                'type' : 'object',
                'properties' : {
                                    'Code' : {'type' : 'string', 'required' : true},
                                    'Name' : {'type' : 'string', 'required' : true},
                                    'Price' : {'type' : 'number', 'required' : true},
                                    'Description' : {'type' : 'string', 'required' : true},
                                    'Type' : {'type' : 'string', 'required' : true},
                                    'ShippingDeliveryType' : {'type' : 'string', 'required' : true},
                                    'imageURL' : {'type' : 'string', 'required' : true},
                                    'Category' : {
                                                    'type' : 'object',
                                                    'properties' : {
                                                                        'Name' : {'type' : 'string', 'required' : true},
                                                                        'Description' : {'type' : 'string', 'required' : true}
                                                                   }
                                                 }
                                },
                  'additionalProperties': false
            }";



        [HttpDelete]
        public HttpResponseMessage DeleteInfo(HttpRequestMessage id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(id.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

            return response;
        }


        [HttpGet]
        public HttpResponseMessage GetInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            List<Product> products = prodServ.Read();
            int index = products.FindIndex(x => x.Code == id);

            if (index != -1)
            {
                Product product = products[index];
                string productJSON = JsonConvert.SerializeObject(product, Formatting.Indented);
                response.Content = new StringContent(productJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error looking for a product with the specified ID.\" }", Encoding.UTF8, "application/json");
            }

            return response;
        }


        [HttpGet]
        public HttpResponseMessage GetInfo2()
        {
            string productJSON = JsonConvert.SerializeObject(prodServ.Read(), Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productJSON, Encoding.UTF8, "application/json");

            return response;
        }



        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            JSchema schema = JSchema.Parse(schemaJson);
            JObject product = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);
            IList<string> errorMessages;
            bool valid = product.IsValid(schema, out errorMessages);
            
            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"Error inserting a new product.\", \"Details\": \"" + errorMessages + "\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                bool created = false;
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Product productJSON = JsonConvert.DeserializeObject<Product>(objeto.Content.ReadAsStringAsync().Result);
                created = prodServ.Create(productJSON);

                if(created == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("{ \"Error\": \"There was an error while creating a new product.\" }", Encoding.UTF8, "application/json");
                }
            }

            return response;
        }



        [HttpPut]
        public HttpResponseMessage UpdateInfo(string id, HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            JSchema schema = JSchema.Parse(schemaJson);
            JObject product = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);
            IList<string> errorMessages;
            bool valid = product.IsValid(schema, out errorMessages);

            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"There was an error updating the product with the specified ID.\", \"Details\": \"" + errorMessages + "\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                bool updated = false;
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Product productJSON = JsonConvert.DeserializeObject<Product>(objeto.Content.ReadAsStringAsync().Result);
                updated = prodServ.Update(id, productJSON);

                if (updated == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("{ \"Error\": \"There was an error updating the product with the specified ID.\" }", Encoding.UTF8, "application/json");
                }
            }

            return response;
        }
    }
}