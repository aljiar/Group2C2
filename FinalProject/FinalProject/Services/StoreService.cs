using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class StoreManager : IService, ICRUD<Store>
    {
        private DB myDB;

        public StoreManager()
        {
            myDB = DB.Instance;
        }

        public bool checkIfExists(string name)
        {
            return myDB.Stores.Exists((x => x.Name == name));
        }

        public bool Create(Store newStore)
        {
            if (!checkIfExists(newStore.Name))
            {
                myDB.Stores.Add(newStore);
                Console.WriteLine("Store was created successfully");
                return true;
            }
            Console.WriteLine("Failed to create store");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);
            if (index != -1)
            {
                myDB.Stores.RemoveAt(index);
                Console.WriteLine("Store was deleted successfully");
                return true;
            }
            Console.WriteLine("Failed to delete store");
            return false;
        }

        public int getIndexByKey(string key)
        {
            return myDB.Stores.FindIndex((x => x.Name == key));
        }

        public List<Store> Read()
        {
            return myDB.Stores;
        }

        public bool Update(string key, Store updatedStore)
        {
            int index = getIndexByKey(key);
            if (index != -1 && key == updatedStore.Name) //key must be the updated object name
            {
                myDB.Stores[index] = updatedStore;
                Console.WriteLine("Store was updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update store information");
            return false;
        }
    }
}
