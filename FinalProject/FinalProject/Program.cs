using FinalProject;
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
            ProductCartManager manager = new ProductCartManager();
            manager.setCart(cart);
            Product prod1 = new Product() { Code = "001", Name = "TV", Price = 10, Description = "Flat screen" };
            Product prod2 = new Product() { Code = "002", Name = "Radio", Price = 10, Description = "New radio" };
            Product prod3 = new Product() { Code = "003", Name = "Table", Price = 5, Description = "Table" };
            ProductCart productCart1 = new ProductCart("1", "Normal", null, 12);
            ProductCart productCart2 = new ProductCart("2", "Normal", null, 12);
            ProductCart productCart3 = new ProductCart("3", "Express", null, 1);

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
          
            StoreManager manager1 = new StoreManager();
            Store store1 = new Store("Tienda1", "line1", "line2", 123);
            Store store2 = new Store("Tienda2", "line1", "line2", 123);
            Store store3 = new Store("Tienda1", "line1", "line2", 123);
            //create
            manager1.Create(store1); //success
            manager1.Create(store2); //success
            manager1.Create(store1); //fail
            //delete
            manager1.Delete("Tienda1"); //success
            manager1.Delete("Tienda3"); //fail
            //update
            store2.Line1 = "newLine";
            manager1.Update("Tienda2", store2); //success
            manager1.Update("Tienda2", store3); //fail
            manager1.Update("Tienda5", store1); //fail
            //read
            show<Store>(manager1.Read());
            List<ShippingAddress> list = new List<ShippingAddress>();
            UserManager manager2 = new UserManager();
            User user1 = new User("max", "pass", "Max", "Mendez", list);
            User user2 = new User("cam", "pass", "Camila", "Mendez", list);
            User user3 = new User("pedro", "pass", "Pedro", "Mendez", list);
            User user4 = new User("pedro", "pass", "Pedro", "Sanchez", list);
            //create
            manager2.Create(user1); //success
            manager2.Create(user2); //success
            manager2.Create(user3); //success
            manager2.Create(user4); //fail
            //delete
            manager2.Delete("pedro"); //success
            manager2.Delete("laura"); //fail
            //update
            user2.Password = "newPass";
            manager2.Update("cam", user2); //success
            manager2.Update("cam", user1); //fail
            manager2.Update("kira", user4); //fail
            //read
            show<User>(manager2.Read());
        }

        public static void CRUDCarts()
        {
            CartManager manager = new CartManager();
            Cart cart1 = new Cart(new List<ProductCart>(), "maria");
            Cart cart2 = new Cart(new List<ProductCart>(), "max");
            Cart cart3 = new Cart(new List<ProductCart>(), "cam");
            Product prod1 = new Product() { Code = "001", Name = "TV", Price = 10, Description = "Flat screen" };
            ProductCart productCart1 = new ProductCart(prod1.Code, "Normal", null, 12);
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

            Product product1 = new Product() { Code = "1", Name = "Producto numero1", Price = 10.99, Category = categoria1, Description = "Descripcion del producto1", Type = "Digital", ShippingDeliveryType = "Express", imageURL = "image1" };
            Product product2 = new Product() { Code = "2", Name = "Producto numero2", Price = 20.50, Category = categoria2, Description = "Descripcion del producto2", Type = "Physical", ShippingDeliveryType = "Free", imageURL = "image2" };
            Product product3 = new Product() { Code = "3", Name = "Producto numero3", Price = 30.50, Category = categoria2, Description = "Descripcion del producto2", Type = "Physical", ShippingDeliveryType = "Free", imageURL = "image3"};

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
