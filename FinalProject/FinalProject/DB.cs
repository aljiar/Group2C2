using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class DB
    {
        private List<List<object>> database;
        public List<List<object>> _database
        {
            get
            {
                return database;
            }
            private set
            {
                if (value != null)
                {
                    database = value;
                }
            }
        }

        private static DB instance;
        public static DB _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DB();
                }
                return instance;
            }
            private set
            {
                if (value != null)
                {
                    instance = value;
                }
            }
        }

        private DB()
        {
            int size = Enum.GetNames(typeof(Indexes)).Length;
            database = new List<List<object>>();
            initializeLists(size);
        }

        private void initializeLists(int number)
        {
            for (int i = 0; i < number; i++)
            {
                database.Add(new List<object>());
            }
        }

        public void addValue(Object obj, Indexes index)
        {
            int dbIndex = (int)index;
            database[dbIndex].Add(obj);
        }
    }
}
