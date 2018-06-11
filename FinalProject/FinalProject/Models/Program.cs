using FinalProject.Services;
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

            testProduct();
        }

        static void testProduct()
        {
            ProductService prodServ = new ProductService();
            CategoryService cateServ = new CategoryService();

            Category categoria1 = new Category() { Name = "categoria1", Description = "descripcion de la primera categoria" };
            Category categoria2 = new Category() { Name = "categoria2", Description = "descripcion de la segunda categoria" };
            Category categoria3 = new Category() { Name = "categoria3", Description = "descripcion de la tercera categoria" };

            Product product1 = new Product() { Code = "1", Name = "Producto numero1", Price = 10.99, Category = categoria1, Description = "Descripcion del producto1", Type = Type1.Digital, ShippingDeliberyType = ShippingDeliveryType1.Express };
            Product product2 = new Product() { Code = "2", Name = "Producto numero2", Price = 20.50, Category = categoria2, Description = "Descripcion del producto2", Type = Type1.Physical, ShippingDeliberyType = ShippingDeliveryType1.Free };
            Product product3 = new Product() { Code = "3", Name = "Producto numero3", Price = 30.50, Category = categoria2, Description = "Descripcion del producto2", Type = Type1.Physical, ShippingDeliberyType = ShippingDeliveryType1.Free };

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
