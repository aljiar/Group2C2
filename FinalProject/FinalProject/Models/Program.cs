using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public enum Indexes
    {
        Cart,
        Category,
        Product,
        ProductCart,
        ShippingAddress,
        Store,
        User
    }

    class Program
    {
        static void Main(string[] args)
        {
            CRUDUsers();
            Console.ReadKey();
        }

        public static void CRUDUsers()
        {
            ShippingAddressManager manager = new ShippingAddressManager();
            ShippingAddress shippingAddress1 = new ShippingAddress("01", "line1", "line2", 123, "La Paz", "Zona 1");
            ShippingAddress shippingAddress2 = new ShippingAddress("02", "line1", "line2", 123, "La Paz", "Zona 1");
            ShippingAddress shippingAddress3 = new ShippingAddress("01", "line1", "line2", 123, "La Paz", "Zona 1");
            //create
            manager.Create(shippingAddress1); //success
            manager.Create(shippingAddress2); //success
            manager.Create(shippingAddress1); //fail
            //delete
            manager.Delete("01"); //success
            manager.Delete("03"); //fail
            //update
            shippingAddress2.Line1 = "newLine";
            manager.Update("02", shippingAddress2); //success
            manager.Update("02", shippingAddress3); //fail
            manager.Update("05", shippingAddress2); //fail
            //read
            show<ShippingAddress>(manager.Read());
        }

        private static void show<T>(List<T> list)
        {
            Console.WriteLine("-----------Printing list-------------");
            foreach (T obj in list)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("------------End of list--------------");
        }
    }
}
