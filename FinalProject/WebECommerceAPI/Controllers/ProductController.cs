using FinalProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
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
            string productJSON = JsonConvert.SerializeObject(prodServ, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productJSON, Encoding.UTF8, "application/json");

            return response;
        }

        [HttpPost]
        public HttpResponseMessage PostInfo(HttpRequestMessage content)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(content.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateInfo(HttpRequestMessage objeto)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(objeto.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");

            return response;
        }
    }
}