using FinalProject.Services;
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
            CRUDUsers();
            testProduct();
            CRUDProductCarts();
            CRUDCarts();
            Console.ReadKey();
        }
        public static void CRUDProductCarts()
        {
            Cart cart = new Cart(new List<ProductCart>(), "maria");
            ProductCartManager manager = new ProductCartManager(cart);
            Product prod1 = new Product() { Code = "001", Name = "TV", Price = 10, Description = "Flat screen" };
            Product prod2 = new Product() { Code = "002", Name = "Radio", Price = 10, Description = "New radio" };
            Product prod3 = new Product() { Code = "003", Name = "Table", Price = 5, Description = "Table" };
            ProductCart productCart1 = new ProductCart("1", ShippingDeliveryType.Normal, null, 12);
            ProductCart productCart2 = new ProductCart("2", ShippingDeliveryType.Normal, null, 12);
            ProductCart productCart3 = new ProductCart("3", ShippingDeliveryType.Express, null, 1);
            //create
            manager.Create(productCart1); //success
            manager.Create(productCart2); //fail
            manager.Create(productCart3); //success
            //delete
            manager.Delete("1"); //fail
            //update
            productCart3.Quantity = 23;
            manager.Update("3", productCart3); //success
            manager.Update("1", productCart2); //fail
            manager.Update("3", productCart1); //fail
            //read
            show<ProductCart>(manager.Read());
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

        public static void CRUDCarts()
        {
            CartManager manager = new CartManager();
            Cart cart1 = new Cart(new List<ProductCart>(), "maria");
            Cart cart2 = new Cart(new List<ProductCart>(), "max");
            Cart cart3 = new Cart(new List<ProductCart>(), "cam");
            Product prod1 = new Product() { Code = "001", Name = "TV", Price = 10, Description = "Flat screen" };
            ProductCart productCart1 = new ProductCart(prod1.Code, ShippingDeliveryType.Normal, null, 12);
            //create
            manager.Create(cart1); //fail
            manager.Create(cart3); //success
            manager.Create(cart2); //success
            //delete
            manager.Delete("max"); //success
            manager.Delete("hola"); //fail
            //update
            cart3.ListProductCart.Add(productCart1);
            manager.Update("cam", cart3);
            manager.Update("cam", cart1);
            //read
            show<Cart>(manager.Read());
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

        static void testProduct()
        {
            ProductService prodServ = new ProductService();
            CategoryService cateServ = new CategoryService();

            Category categoria1 = new Category() { Name = "categoria1", Description = "descripcion de la primera categoria" };
            Category categoria2 = new Category() { Name = "categoria2", Description = "descripcion de la segunda categoria" };
            Category categoria3 = new Category() { Name = "categoria3", Description = "descripcion de la tercera categoria" };

            Product product1 = new Product() { Code = "1", Name = "Producto numero1", Price = 10.99, Category = categoria1, Description = "Descripcion del producto1", Type = Type1.Digital, ShippingDeliberyType = ShippingDeliveryType.Express };
            Product product2 = new Product() { Code = "2", Name = "Producto numero2", Price = 20.50, Category = categoria2, Description = "Descripcion del producto2", Type = Type1.Physical, ShippingDeliberyType = ShippingDeliveryType.Free };
            Product product3 = new Product() { Code = "3", Name = "Producto numero3", Price = 30.50, Category = categoria2, Description = "Descripcion del producto2", Type = Type1.Physical, ShippingDeliberyType = ShippingDeliveryType.Free };

            cateServ.Create(categoria1);
            cateServ.Create(categoria2);
            cateServ.Create(categoria1);
            cateServ.Update("categoria2",categoria3);

            Console.WriteLine("---------------CATEGORIES IN THE DATA BASE------------\n");

            foreach (Category c in cateServ.Read())
            {
                c.showCategories();
            }

            prodServ.Create(product1);
            prodServ.Create(product2);
            prodServ.Create(product1);
            prodServ.Delete(product2.Code);
            prodServ.Update("1", product3);

            Console.WriteLine("---------------PRODUCTS IN THE DATA BASE------------\n");

            foreach (Product p in prodServ.Read())
            {
                p.showProducts();
            }

        }
    }
}
