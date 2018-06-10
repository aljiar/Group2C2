using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public enum Type1 {Physical, Digital};
        public Type1 Type { get; set; }
        public enum ShippingDeliveryType1 {Express, Normal, InStore, Free, None};
        public ShippingDeliveryType1 ShippingDeliberyType { get; set; }
        public Category Category { get; set; }
    }
}
