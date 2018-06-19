using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject
{
    public class ShippingAddress
    {
        [JsonProperty(Required = Required.Always)]
        public string Identifier { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Line1 { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Line2 { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int Phone { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string City { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Zone { get; set; }

        public ShippingAddress(string identifier, string line1, string line2, int phone, string city, string zone)
        {
            Identifier = identifier;
            Line1 = line1;
            Line2 = line2;
            Phone = phone;
            City = city;
            Zone = zone;
        }

        public override string ToString()
        {
            return "Identifier: " + Identifier + ", line1: " + Line1 + ", line2: " + Line2 + ", phone: " + Phone + ", city: " + City + ", zone: " + Zone;
        }
    }


}
