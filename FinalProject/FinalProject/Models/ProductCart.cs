using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject
{
    public class ProductCart
    {
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string SelectedDelivery { get; set; }
        //[JsonProperty(Required = Required.Always)]
        public Store Store { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int Quantity { get; set; }

        public ProductCart(string productCode, string selectedDelivery, Store store, int quantity)
        {
            ProductCode = productCode;
            SelectedDelivery = selectedDelivery;
            assignStore(selectedDelivery, store);
            Quantity = quantity;
        }

        private void assignStore(string selectedDelivery, Store store)
        {
            if (selectedDelivery == "InStore")
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
