using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject
{
    public class Product
    {
        [JsonProperty(Required = Required.Always)]
        public string Code { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public double Price { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ShippingDeliveryType { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string imageURL { get; set; }
        [JsonProperty(Required = Required.Always)]
        public Category Category { get; set; }


        public Product()
        { }

        public void showProducts()
        {
            Console.WriteLine("CODE: " + Code);
            Console.WriteLine("NAME: " + Name);
            Console.WriteLine("PRICE: " + Price);
            Console.WriteLine("DESCRIPTION: " + Description);
            Console.WriteLine("TYPE: " + Type);
            Console.WriteLine("SHIPPING DELIBERY TYPE: " + ShippingDeliveryType);
            Console.WriteLine("CATEGORY: " + Category);
        }
    }
}
