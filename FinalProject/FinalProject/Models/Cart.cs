using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject
{
    public class Cart
    {
        [JsonProperty(Required = Required.Always)]
        public List<ProductCart> ListProductCart { get; set; }
        [JsonProperty(Required = Required.Always)]
        public String Username { get; set; }
        [JsonProperty(Required = Required.Always)]
        public bool Dispatched { get; set; }

        public Cart(List<ProductCart> list, string username)
        {
            Username = username;
            ListProductCart = list;
            Dispatched = false;
        }

        public override string ToString()
        {
            string stringCart = "Username: " + Username + "\nProductCarts:";
            foreach (ProductCart prodCart in ListProductCart)
            {
                stringCart += "\n\t" + prodCart.ToString();
            }
            return stringCart;
        }
    }
}
