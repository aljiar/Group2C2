using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject
{
    public class User
    {
        [JsonProperty(Required = Required.Always)]
        public string Username { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string LastName { get; set; }
        [JsonProperty(Required = Required.Always)]
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

