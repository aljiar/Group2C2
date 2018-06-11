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
                Console.WriteLine("El usuario ya posee un carrito");
                return false;
            }
            dbCart.Carts.Add(objeto);
            Console.WriteLine("Se creo el carrito correctamente");
            return true;
        }

        public bool Delete(string key)
        {
            int index;
            if ((index = dbCart.Carts.FindIndex(cart => { return cart.Username == key; })) < 0)
            {
                Console.WriteLine("No se puede eliminar el carrito por que no existe");
                return false;
            }
            dbCart.Carts.RemoveAt(index);
            Console.WriteLine("Se elimino el carrito correctamente");
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
                Console.WriteLine("No se puede actualizar el carrito");
                return false;
            }
            int index;
            if ((index = dbCart.Carts.FindIndex(cart => { return cart.Username == key; })) < 0)
            {
                Console.WriteLine("No se puede actualizar el carrito");
                return false;
            }
            dbCart.Carts[index] = updatedObject;
            Console.WriteLine("Se actualizo el carrito correctamente");
            return true;
        }
    }
}
