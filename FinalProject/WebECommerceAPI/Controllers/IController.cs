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

        HttpResponseMessage GetInfo(int id);

        HttpResponseMessage PostInfo(Object content);

        HttpResponseMessage UpdateInfo(Object res);

        HttpResponseMessage DeleteInfo(Object id);
    }
}
