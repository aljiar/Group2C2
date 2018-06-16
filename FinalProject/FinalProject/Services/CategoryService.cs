using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class CategoryService : ICRUD<Category>, IService
    {
        private static DB DBCategory = DB.Instance;

        public bool checkIfExists(string key)
        {
            return DBCategory.Categories.Exists(x => x.Name == key);
        }

        public int getIndexByKey(string key)
        {
            return DBCategory.Categories.FindIndex(x => x.Name == key);
        }


        public bool Create(Category objeto)
        {
            if (!checkIfExists(objeto.Name))
            {
                Console.WriteLine("Adding a new Category...");
                DBCategory.Categories.Add(objeto);
                return true;
            }

            Console.WriteLine("No se puede agregar la categoria.");
            return false;
        }

        public bool Delete(string key)
        {
            int index = getIndexByKey(key);

            if (index != -1)
            {
                Console.WriteLine("Eliminando la categoria con codigo = " + key);
                DBCategory.Categories.RemoveAt(index);
                return true;
            }

            Console.WriteLine("No se puede borrar la categoria con codigo " + key + " porque no existe en la base de datos.");
            return false;
        }

        public List<Category> Read()
        {
            if (!DBCategory.Categories.Any())
            {
                Console.WriteLine("The List of Categories is Empty!");
            }

            Console.WriteLine("List of categories in the DataBase:\n");
            return DBCategory.Categories;
        }

        public bool Update(string key, Category updatedObject)
        {
            int indice = getIndexByKey(key);

            if (indice != -1)
            {
                Console.WriteLine("Updating the product " + updatedObject.Name);
                DBCategory.Categories[indice] = updatedObject;
                return true;
            }
            return false;
        }
    }
}
