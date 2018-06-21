using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class ShippingAddressService : IService, ICRUD<ShippingAddress>
    {
        private DB myDB;

        public ShippingAddressService()
        {
            myDB = DB.Instance;
        }

        public bool checkIfExists(string identifier)
        {
            return myDB.ShippingAddresses.Exists((x => x.Identifier == identifier));
        }

        public bool Create(ShippingAddress shippingAddress)
        {
            if (!checkIfExists(shippingAddress.Identifier))
            {
                myDB.ShippingAddresses.Add(shippingAddress);
                Console.WriteLine("Shipping address was created successfully");
                return true;
            }
            Console.WriteLine("Failed to create shipping address");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);
            if (index != -1)
            {
                myDB.ShippingAddresses.RemoveAt(index);
                Console.WriteLine("Shipping address was deleted successfully");
                return true;
            }
            Console.WriteLine("Failed to delete shipping address");
            return false;
        }

        public int getIndexByKey(string key)
        {
            return myDB.ShippingAddresses.FindIndex((x => x.Identifier == key));
        }

        public List<ShippingAddress> Read()
        {
            return myDB.ShippingAddresses;
        }

        public bool Update(string key, ShippingAddress updatedShippingAddress)
        {
            int index = getIndexByKey(key);
            if (index != -1 && key == updatedShippingAddress.Identifier) //key must be the updated object identifier
            {
                myDB.ShippingAddresses[index] = updatedShippingAddress;
                Console.WriteLine("Shipping address was updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update shipping address information");
            return false;
        }
    }
}