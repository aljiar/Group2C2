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
            List<ShippingAddress> list = new List<ShippingAddress>();
            UserManager manager = new UserManager();
            User user1 = new User("max", "pass", "Max", "Mendez", list);
            User user2 = new User("cam", "pass", "Camila", "Mendez", list);
            User user3 = new User("pedro", "pass", "Pedro", "Mendez", list);
            User user4 = new User("pedro", "pass", "Pedro", "Sanchez", list);
            //create
            manager.Create(user1); //success
            manager.Create(user2); //success
            manager.Create(user3); //success
            manager.Create(user4); //fail
            //delete
            manager.Delete("pedro"); //success
            manager.Delete("laura"); //fail
            //update
            user2.Password = "newPass";
            manager.Update("cam", user2); //success
            manager.Update("cam", user1); //fail
            manager.Update("kira", user4); //fail
            //read
            show<User>(manager.Read());
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
