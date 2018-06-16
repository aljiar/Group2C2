using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Store
    {
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Phone { get; set; }

        public Store(string name, string line1, string line2, int phone)
        {
            Name = name;
            Line1 = line1;
            Line2 = line2;
            Phone = phone;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", line1: " + Line1 + ", line2: " + Line2 + ", phone: " + Phone; 
        }
    }
}
