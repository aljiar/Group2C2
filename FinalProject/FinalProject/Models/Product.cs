using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public enum ShippingDeliveryType
    {
        Express,
        Normal,
        InStore,
        Free,
        None
    };
    class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public enum Type1 {Physical, Digital};
        public Type1 Type { get; set; }
        public ShippingDeliveryType ShippingDeliveryType1 { get; set; }
        public Category Category { get; set; }
    }
}
