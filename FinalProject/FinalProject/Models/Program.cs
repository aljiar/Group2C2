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
            CRUDCarts();
            Console.ReadKey();
        }

        public static void CRUDCarts()
        {

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
