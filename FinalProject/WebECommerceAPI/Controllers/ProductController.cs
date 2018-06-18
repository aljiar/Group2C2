using FinalProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebECommerceAPI.Controllers
{
    public class ProductController : ApiController, IController
    {
        ProductService prodServ = new ProductService();

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
            string productJSON = JsonConvert.SerializeObject(prodServ, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productJSON, Encoding.UTF8, "application/json");


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

            JSchema schema = JSchema.Parse(schemaJson);
            JObject product = JObject.Parse(objeto.Content.ReadAsStringAsync().Result);

            bool valid = product.IsValid(schema);
            
            if (!valid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent("{ \"Error\": \"Error inserting a new product.\" }", Encoding.UTF8, "application/json");
            }
            else
            {
                response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

                Product productJSON = JsonConvert.DeserializeObject<Product>(objeto.Content.ReadAsStringAsync().Result);
                prodServ.Create(productJSON);
            }

            return response;
        }


        [HttpPut]
        public HttpResponseMessage UpdateInfo(string id, HttpRequestMessage objeto)
        {
            Product productJSON = JsonConvert.DeserializeObject<Product>(objeto.Content.ReadAsStringAsync().Result);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

            prodServ.Update(id, productJSON);

            return response;
        }
    }
}