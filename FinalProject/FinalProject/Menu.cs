using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    class Menu
    {
        private int option;
        private List<User> listaUser;
        public void desplegar()
        {
            listaUser = new List<User>();

            do
            {
                do
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("MENU");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("1.- Registrar un usuario");
                    Console.WriteLine("2.- listar un usuario");
                    Console.WriteLine("3.- Eliminar un usuario");
                    Console.WriteLine("4.- Buscar un usuario");
                    Console.WriteLine("5.- modificar");
                    Console.WriteLine("6.- salir");
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Digite la opcion");
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------");
                    if (option < 1 || option > 6)
                    {
                        Console.WriteLine("opcio invalida escoja una opcion de 1 a 6");
                    }


                } while (option < 1 || option > 6);

                switch (option)
                {
                    case 1:
                        /*registrar usuario*/
                        {
                            string leer;

                            User usernew = new User();

                            Console.WriteLine("Username:");
                            leer = Console.ReadLine();


                            usernew.Username = leer;
                            Console.WriteLine("password:");
                            usernew.Password = Console.ReadLine();
                            Console.WriteLine("Name:");
                            usernew.Name = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            usernew.Lastname = Console.ReadLine();
                            listaUser.Add(usernew);



                            break;
                        }

                    case 2:
                        /*listar usuario*/
                        {

                            foreach (User u in listaUser)
                            {
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("Username: " + u.Username);
                                Console.WriteLine("Password: " + u.Password);
                                Console.WriteLine("Name: " + u.Name);
                                Console.WriteLine("Last Name: " + u.Lastname);
                                Console.WriteLine("-----------------------------------------");
                            }

                            break;
                        }

                    case 3:
                        /*eliminar usuario*/
                        {
                            string eliminarusername;
                            Console.WriteLine("ingrese el UserName que desee eliminar");
                            eliminarusername = Console.ReadLine();
                            listaUser.RemoveAll(b => b.Username == eliminarusername);


                            break;
                        }

                    case 4:
                        /*buscar usuario*/
                        {

                            Console.WriteLine("user name a buscar: ");
                            string usernamebuscar = Console.ReadLine();
                            foreach (User u in listaUser)
                            {
                                if (u.Username == usernamebuscar)
                                {
                                    Console.WriteLine("Username: " + u.Username);
                                    Console.WriteLine("Password: " + u.Password);
                                    Console.WriteLine("Name: " + u.Name);
                                    Console.WriteLine("Last Name: " + u.Lastname);

                                    break;
                                }
                            }
                            break;
                        }

                    case 5:
                        /*modificar*/
                        {
                            string lee;
                            Console.WriteLine("ingrese el nombre de usuario que desea modificar");
                            lee = Console.ReadLine();
                            foreach (User us in listaUser)
                            {
                                if (lee == us.Username)
                                {
                                    listaUser.Remove(us);
                                    string leer;
                                    Console.WriteLine("Ingrese El Nuevo Username:");
                                    leer = Console.ReadLine();
                                    us.Username = leer;
                                    Console.WriteLine("Ingrese El Nuevo password:");
                                    us.Password = Console.ReadLine();
                                    Console.WriteLine("Ingrese El Nuevo Name:");
                                    us.Name = Console.ReadLine();
                                    Console.WriteLine("Ingrese El Nuevo Last Name:");
                                    us.Lastname = Console.ReadLine();
                                    listaUser.Add(us);
                                    break;
                                }
                            }
                            break;
                        }
                    /*salir*/
                    case 6:
                        {

                            Console.WriteLine("gracias por utilizar la aplicacion");
                            Console.ReadLine();
                            break;
                        }

                }



            } while (option != 6);
        }





    }
}
