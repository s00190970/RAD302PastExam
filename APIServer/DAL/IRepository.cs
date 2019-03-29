using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServer.DAL
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Add(T item);
        bool Edit(T item);
    }
}
