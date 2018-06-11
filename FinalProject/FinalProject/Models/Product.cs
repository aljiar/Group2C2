using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
<<<<<<< HEAD
    public enum ShippingDeliveryType
    {
=======
    public enum ShippingDeliveryType {
>>>>>>> 3d7e367d886e7c354fdbade8c273d59ff4877931
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
<<<<<<< HEAD
        public ShippingDeliveryType ShippingDeliveryType { get; set; }
=======
        public ShippingDeliveryType ShippingDeliveryType1 { get; set; }
>>>>>>> 3d7e367d886e7c354fdbade8c273d59ff4877931
        public Category Category { get; set; }
    }
}
