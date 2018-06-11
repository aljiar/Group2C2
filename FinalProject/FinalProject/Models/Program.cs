using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDProductCarts();
            Console.ReadKey();
        }

        public static void CRUDProductCarts()
        {
            ProductCartManager manager = new ProductCartManager();
            Product prod1 = new Product() { Code = "001", Name = "TV", Price = 10, Description = "Flat screen" };
            Product prod2 = new Product() { Code = "002", Name = "Radio", Price = 10, Description = "New radio" };
            Product prod3 = new Product() { Code = "003", Name = "Table", Price = 5, Description = "Table" };
            ProductCart productCart1 = new ProductCart(prod1.Code, ShippingDeliveryType.Normal, null, 12);
            ProductCart productCart2 = new ProductCart(prod2.Code, ShippingDeliveryType.Normal, null, 12);
            ProductCart productCart3 = new ProductCart(prod3.Code, ShippingDeliveryType.Express, null, 1);
            //create
            Console.WriteLine(manager.create(productCart1)); //true
            Console.WriteLine(manager.create(productCart2)); //true
            Console.WriteLine(manager.create(productCart1)); //false
            //delete
            Console.WriteLine(manager.delete("001")); //true
            Console.WriteLine(manager.delete("003")); //false
            //update
            productCart2.Quantity = 23;
            Console.WriteLine(manager.update("002", productCart2)); //true
            Console.WriteLine(manager.update("001", productCart2)); //false
            Console.WriteLine(manager.update("002", productCart3)); //false
            //read
            show<ProductCart>(manager.read());
        }

        private static void show<T>(List<T> list)
        {
            Console.WriteLine("-----------Printing list-------------");
            foreach(T obj in list)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("------------End of list--------------");
        }
    }
}
