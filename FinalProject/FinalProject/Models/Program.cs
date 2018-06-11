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
            StoreManager manager = new StoreManager();
            Store store1 = new Store("Tienda1", "line1", "line2", 123);
            Store store2 = new Store("Tienda2", "line1", "line2", 123);
            Store store3 = new Store("Tienda1", "line1", "line2", 123);
            //create
            manager.Create(store1); //success
            manager.Create(store2); //success
            manager.Create(store1); //fail
            //delete
            manager.Delete("Tienda1"); //success
            manager.Delete("Tienda3"); //fail
            //update
            store2.Line1 = "newLine";
            manager.Update("Tienda2", store2); //success
            manager.Update("Tienda2", store3); //fail
            manager.Update("Tienda5", store1); //fail
            //read
            show<Store>(manager.Read());
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
