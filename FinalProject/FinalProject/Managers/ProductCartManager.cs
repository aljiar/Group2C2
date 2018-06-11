using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
<<<<<<< HEAD
    class ProductCartManager : IManager, ICRUD<ProductCart>
    {
        private Cart cart;

        public ProductCartManager(Cart cart)
        {
            this.cart = cart;
        }

        public bool checkIfExists(string productCode)
        {
            return cart.ListProductCart.Exists((x => x.ProductCode == productCode));
        }

        public int getIndexByKey(string productCode)
        {
            return cart.ListProductCart.FindIndex((x => x.ProductCode == productCode));
        }

        public bool Create(ProductCart prodCart)
        {
            ProductManager prodManager = new ProductManager();
            if (!checkIfExists(prodCart.ProductCode) && prodManager.checkIfExists(prodCart.ProductCode))
            {
                cart.ListProductCart.Add(prodCart);
                Console.WriteLine("Product cart was created successfully");
                return true;
            }
            Console.WriteLine("Failed to create product cart");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);
            if (index != -1)
            {
                cart.ListProductCart.RemoveAt(index);
                Console.WriteLine("Product cart was deleted successfully");
                return true;
            }
            Console.WriteLine("Failed to delete product cart");
            return false;
        }

        public bool Update(string key, ProductCart updatedProductCart)
        {
            int index = getIndexByKey(key);
            if (index != -1 && key == updatedProductCart.ProductCode) //key must be the product code
            {
                cart.ListProductCart[index] = updatedProductCart;
                Console.WriteLine("Product cart was updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update product cart information");
            return false;
        }

        public List<ProductCart> Read()
        {
            return cart.ListProductCart;
=======
    class ProductCartManager
    {
        private DB myDB;

        public ProductCartManager()
        {
            myDB = DB.Instance;
        }

        public bool checkIfProductCartExists(string productCode)
        {
            return myDB.ProductCarts.Exists((x => x.ProductCode == productCode));
        }

        private int getProductCartIndexByKey(string productCode)
        {
            return myDB.ProductCarts.FindIndex((x => x.ProductCode == productCode));
        }

        public bool create(ProductCart prodCart)
        {
            if (!checkIfProductCartExists(prodCart.ProductCode))
            {
                myDB.ProductCarts.Add(prodCart);
                return true;
            }
            return false;
        }

        public bool delete(string key)
        {
            int index = getProductCartIndexByKey(key);
            if (index != -1)
            {
                myDB.ProductCarts.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool update(string key, ProductCart updatedProductCart)
        {
            int index = getProductCartIndexByKey(key);
            if (index != -1 && key == updatedProductCart.ProductCode) //key must be the product code
            {
                myDB.ProductCarts[index] = updatedProductCart;
                return true;
            }
            return false;
        }

        public List<ProductCart> read()
        {
            return myDB.ProductCarts;
>>>>>>> 3d7e367d886e7c354fdbade8c273d59ff4877931
        }
    }
}
