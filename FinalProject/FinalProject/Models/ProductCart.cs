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
        public ShippingDeliveryType1 SelectedDelivery { get; set; }
        private Store Store { get; set; }
        public int Quantity { get; set; }

        public ProductCart(string productCode, ShippingDeliveryType1 selectedDelivery, Store store, int quantity)
        {
            ProductCode = productCode;
            SelectedDelivery = selectedDelivery;
            assignStore(selectedDelivery, store);
            Quantity = quantity;
        }

        private void assignStore(ShippingDeliveryType1 selectedDelivery, Store store)
        {
            if (selectedDelivery == ShippingDeliveryType1.InStore)
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
            /*if (Store != null)
            {
                stringProductCart += ", store: " + Store.ToString();
            }*/
            stringProductCart += ", quantity: " + Quantity;
            return stringProductCart;
        }
    }
}
