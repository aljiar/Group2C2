using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface ICRUD<T>
    {
        bool Create(T objeto);
        List<T> Read();
        bool Update(String key, T updatedObject);
        bool Delete(String key);
    }
}
