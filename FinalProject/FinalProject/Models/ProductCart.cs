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
        public ShippingDeliveryType SelectedDelivery { get; set; }
        private Store Store { get; set; }
        public int Quantity { get; set; }

        public ProductCart(string productCode, ShippingDeliveryType selectedDelivery, Store store, int quantity)
        {
            ProductCode = productCode;
            SelectedDelivery = selectedDelivery;
            assignStore(selectedDelivery, store);
            Quantity = quantity;
        }

        private void assignStore(ShippingDeliveryType selectedDelivery, Store store)
        {
            if (selectedDelivery == ShippingDeliveryType.InStore)
            {
                Store = store;
            }
            else
            {
                Store = null;
            }
        }

        public override string ToString()
        {
            string stringProductCart = "Product code: " + ProductCode + ", selected delivery: " + SelectedDelivery;
            stringProductCart += ", quantity: " + Quantity;
            return stringProductCart;
        }
    }
}
