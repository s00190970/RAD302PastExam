using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace APIServer.DAL
{
    public interface IModuleRepository:IRepository<Module>, IDisposable
    {
        Module GetById(int Id);
        bool Remove(int id);
    }
}
