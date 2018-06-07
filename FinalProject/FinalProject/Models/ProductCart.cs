using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ProductCart
    {
        public string ProductCode { get; set; }
        public string SelectedDelivery { get; set; }
        public Store Store { get; set; }
        public int Quantity { get; set; }
    }
}
