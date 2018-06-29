﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class CartService : IService, ICRUD<Cart>
    {
        private DB myDB;

        public CartService()
        {
            myDB = DB.Instance;
        }

        public bool checkIfExists(string username)
        {
            return myDB.Carts.Exists(x => (x.Username == username && !x.Dispatched));
        }

        public bool Create(Cart newCart)
        {
            UserService manager = new UserService();
            if (!checkIfExists(newCart.Username) && manager.checkIfExists(newCart.Username))
            {
                myDB.Carts.Add(newCart);
                Console.WriteLine("Cart was created successfully");
                return true;
            }
            Console.WriteLine("Failed to create cart");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);
            if (index != -1)
            {
                myDB.Carts.RemoveAt(index);
                Console.WriteLine("Cart was deleted successfully");
                return true;
            }
            Console.WriteLine("Failed to delete cart");
            return false;
        }

        public List<Cart> GetDispatchedCarts(string username)
        {
            return myDB.Carts.Where(x => (x.Username == username && x.Dispatched)).ToList();
        }

        public int getIndexByKey(string key)
        {
            return myDB.Carts.FindIndex(x => x.Username == key && !x.Dispatched);
        }

        public List<Cart> Read()
        {
            return myDB.Carts;
        }

        public bool Update(string key, Cart updatedCart)
        {
            int index = getIndexByKey(key);
            if (index != -1 && key == updatedCart.Username) //key must be the username
            {
                myDB.Carts[index] = updatedCart;
                Console.WriteLine("Cart was updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update cart information");
            return false;
        }
    }
}
