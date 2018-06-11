using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class UserManager : IManager, ICRUD<User>
    {
        private DB myDB;

        public UserManager()
        {
            myDB = DB.Instance;
        }

        public bool checkIfExists(string username)
        {
            return myDB.Users.Exists((x => x.Username == username));
        }

        public int getIndexByKey(string username)
        {
            return myDB.Users.FindIndex((x => x.Username == username));
        }

        public bool Create(User user)
        {
            if (!checkIfExists(user.Username))
            {
                myDB.Users.Add(user);
                Console.WriteLine("User was created successfully");
                return true;
            }
            Console.WriteLine("Failed to create user");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);
            if (index != -1)
            {
                myDB.Users.RemoveAt(index);
                Console.WriteLine("User was deleted successfully");
                return true;
            }
            Console.WriteLine("Failed to delete user");
            return false;
        }

        public bool Update(string key, User updatedUser)
        {
            int index = getIndexByKey(key);
            if (index != -1 && key == updatedUser.Username) //key must be the username
            {
                myDB.Users[index] = updatedUser;
                Console.WriteLine("User was updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update user information");
            return false;
        }

        public List<User> Read()
        {
            return myDB.Users;
        }
    }
}
