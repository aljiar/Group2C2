using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ShippingAddress
    {
        public string Identifier { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
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
