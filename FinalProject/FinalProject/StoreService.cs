using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class StoreService
    {
        private int a;
        private List<Store> listStore;

        public void Show()
        {
            listStore = new List<Store>();

            do
            {
                do
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("1. Crear tienda: ");
                    Console.WriteLine("2. Listar tiendas: ");
                    Console.WriteLine("3. Actualizar datos de la tienda: ");
                    Console.WriteLine("4. Eliminar datos de la tienda: ");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Inserte la opcion que desea: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------");
                    if (a < 1 || a > 6)
                    {
                        Console.WriteLine("Opcion no valida!!");
                    }


                } while (a < 1 || a > 6);



                switch (a)
                {
                    case 1:
                       
                        {


                            Store nstore = new Store();

                            Console.WriteLine("Name: ");
                            nstore.Name = Console.ReadLine();
                            Console.WriteLine("Line 1:");
                            nstore.Line1 = Console.ReadLine();
                            Console.WriteLine("Line 2:");
                            nstore.Line2 = Console.ReadLine();
                            Console.WriteLine("Phone:");
                            nstore.Phone = Int32.Parse(Console.ReadLine());
                  
                            listStore.Add(nstore);


                            break;
                        }

                    case 2:

                        {



                            foreach (Store storesrv in listStore)
                            {
                                Console.WriteLine("-----------------------");
                                Console.WriteLine("Nombre: " + storesrv.Name);
                                Console.WriteLine("Line 1: " + storesrv.Line1);
                                Console.WriteLine("Line 2: " + storesrv.Line2);
                                Console.WriteLine("Phone: " + storesrv.Phone);
                                Console.WriteLine("-----------------------");
                            }

                            break;
                        }

                    case 3:

                        {
                            string update;
                            Console.WriteLine("Ingrese el nombre de la tienda que desea actualizar: ");
                            update = Console.ReadLine();
                            foreach (Store storesrv in listStore)
                            {
                                if (update == storesrv.Name)
                                {
                                    listStore.Remove(storesrv);
                                    string updatestore;
                                    Console.WriteLine("Ingrese El Nuevo Line 1:");
                                    updatestore = Console.ReadLine();
                                    storesrv.Name = updatestore;
                                    Console.WriteLine("Ingrese El Nuevo Line 2:");
                                    storesrv.Line1 = Console.ReadLine();
                                    Console.WriteLine("Ingrese El Nuevo Telefono:");
                                    storesrv.Line2 = Console.ReadLine();

                                    break;
                                }
                            }
                            break;

                            
                        }



                    case 4:

                        {
                            string delete;
                            Console.WriteLine("Ingrese el nombre de la tienda que desea eliminar: ");
                            delete = Console.ReadLine();
                            listStore.RemoveAll(b => b.Name == delete);


                            break;

                        }

                    case 5:
                        {


                            Console.WriteLine("ADIOS!!!");
                            Console.ReadKey();
                            break;
                        }

                }



            } while (a != 6);
        }
    }
}