using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<ShippingAddress> ShippingAddressesList { get; set; }

        public User(string username, string password, string name, string lastname, List<ShippingAddress> shippingAddressesList)
        {
            Username = username;
            Password = password;
            Name = name;
            LastName = lastname;
            ShippingAddressesList = shippingAddressesList;
        }

        public override string ToString()
        {
            return "Username: " + Username + ", password:" + Password + ", name: " + Name + ", lastname: " + LastName;
        }
    }
}

