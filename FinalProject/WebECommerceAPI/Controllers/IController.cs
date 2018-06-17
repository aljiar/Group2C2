using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebECommerceAPI.Controllers
{
    interface IController
    {
        HttpResponseMessage GetInfo2();

        HttpResponseMessage GetInfo(string id);

        HttpResponseMessage PostInfo(HttpRequestMessage objeto);

        HttpResponseMessage UpdateInfo(string id, HttpRequestMessage objeto);

        HttpResponseMessage DeleteInfo(HttpRequestMessage id);
    }
}
