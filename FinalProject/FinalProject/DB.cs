using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class DB
    {
        public List<Cart> Carts { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
        public List<ShippingAddress> ShippingAddresses { get; set; }
        public List<Store> Stores { get; set; }
        public List<User> Users { get; set; }

        private static DB instance;
        public static DB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DB();
                }
                return instance;
            }
            private set
            {
                if (value != null)
                {
                    instance = value;
                }
            }
        }

        private DB()
        {
            Carts = new List<Cart>();
            Categories = new List<Category>();
            Products = new List<Product>();
            ProductCarts = new List<ProductCart>();
            ShippingAddresses = new List<ShippingAddress>();
            Stores = new List<Store>();
            Users = new List<User>();
        }
    }
}

