using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    class ServiceCart : ICRUD<Cart>
    {
        private static DB dbCart = DB.Instance;
        public bool Create(Cart objeto)
        {
            if (dbCart.Carts.Exists(cart => { return cart.Username == objeto.Username; }))
            {
                return false;
            }
            dbCart.Carts.Add(objeto);
            return true;
        }

        public bool Delete(string key)
        {
            int index;
            if ((index = dbCart.Carts.FindIndex(cart => { return cart.Username == key; })) < 0)
            {
                return false;
            }
            dbCart.Carts.RemoveAt(index);
            return true;
        }

        public List<Cart> Read()
        {
            return dbCart.Carts;
        }

        public bool Update(string key, Cart updatedObject)
        {
            if (key != updatedObject.Username)
            {
                return false;
            }
            int index;
            if ((index = dbCart.Carts.FindIndex(cart => { return cart.Username == key; })) < 0)
            {
                return false;
            }
            dbCart.Carts[index] = updatedObject;
            return true;
        }
    }
}
