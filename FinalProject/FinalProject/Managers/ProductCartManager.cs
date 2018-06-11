using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
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
        }
    }
}
