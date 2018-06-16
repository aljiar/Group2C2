using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }        
        public string Type { get; set; }
        public string ShippingDeliberyType { get; set; }
        public Category Category { get; set; }


        public Product()
        { }

        public void showProducts()
        {
            Console.WriteLine("CODE: " + Code);
            Console.WriteLine("NAME: " + Name);
            Console.WriteLine("PRICE: " + Price);
            Console.WriteLine("DESCRIPTION: " + Description);
            Console.WriteLine("TYPE: " + Type);
            Console.WriteLine("SHIPPING DELIBERY TYPE: " + ShippingDeliberyType);
            Console.WriteLine("CATEGORY: " + Category);
        }
    }
}
