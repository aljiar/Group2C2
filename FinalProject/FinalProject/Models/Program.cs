using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public enum Indexes
    {
        Cart,
        Category,
        Product,
        ProductCart,
        ShippingAddress,
        Store,
        User
    }

    class Program
    {
        static void Main(string[] args)
        {
            DB mydb = DB._instance;
            Console.WriteLine(mydb._database.Count);
            StoreService showstoresrv = new StoreService();
            showstoresrv.Show();
            
        }
    }
}
