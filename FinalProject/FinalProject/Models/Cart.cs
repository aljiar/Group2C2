using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Cart
    {
        public List<ProductCart> ListProductCart { get; set; }
        public String Username { get; set; }
        public Cart(List<ProductCart> list, string username)
        {
            Username = username;
            foreach (ProductCart prodCart in list)
            {
                ListProductCart.Add(prodCart);
            }
        }

        public override string ToString()
        {
            string stringCart = "Username: " + Username + "\nProductCarts:";
            foreach (ProductCart prodCart in ListProductCart)
            {
                stringCart += "\n\t" + prodCart.ToString();
            }
            return stringCart;
        }
    }
}
