using FinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class ProductCartManager : IService, ICRUD<ProductCart>
    {
        private Cart cart;

        public void setCart(Cart cart)
        {
            this.cart = cart;
        }

        public bool checkIfExists(string productCode)
        {
            if (cart != null)
            {
                return cart.ListProductCart.Exists((x => x.ProductCode == productCode));
            }
            return false;
        }

        public int getIndexByKey(string productCode)
        {
            if (cart != null)
            {
                return cart.ListProductCart.FindIndex((x => x.ProductCode == productCode));
            }
            return -1;
        }

        public bool Create(ProductCart prodCart)
        {
            ProductService prodManager = new ProductService();
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
        }
    }
}
