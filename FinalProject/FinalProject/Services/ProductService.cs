using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    class ProductService : ICRUD<Product>, IManager
    {
        private static DB DBProduct = DB.Instance;


        public bool checkIfExists(string key)
        {
            return DBProduct.Products.Exists(x => x.Code == key);    
        }

        public int getIndexByKey(string key)
        {
            return DBProduct.Products.FindIndex(x => x.Code == key);
        }


        public bool Create(Product objeto)
        {
            if (!checkIfExists(objeto.Code))
            {
                Console.WriteLine("Adding a new Product...");
                DBProduct.Products.Add(objeto);
                return true;
            }

            Console.WriteLine("No se puede agregar el producto.");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);

            if (index != -1)
            {
                Console.WriteLine("Eliminando el producto con codigo = " + key);
                DBProduct.Products.RemoveAt(index);
                return true;
            }

            Console.WriteLine("No se puede borrar el producto con codigo " + key + " porque no existe en la base de datos.");
            return false;
        }


        public List<Product> Read()
        {
            if (!DBProduct.Products.Any())
            {
                Console.WriteLine("The List of Products is Empty!");
            }

            Console.WriteLine("List of products in the DataBase:\n");
            return DBProduct.Products;
        }

        public bool Updata(string key, Product updatedObject)
        {
            int indice = getIndexByKey(key);

            if (indice != -1)
            {
                Console.WriteLine("Updating the product " + updatedObject.Code);
                DBProduct.Products[indice] = updatedObject;
                return true;
            }
            return false;
        }
    }
}
