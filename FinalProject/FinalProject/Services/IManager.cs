using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface IManager
    {
        bool checkIfExists(string key);
        int getIndexByKey(string key);
    }
}
