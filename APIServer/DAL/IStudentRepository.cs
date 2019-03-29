using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace APIServer.DAL
{
    public interface IStudentRepository:IRepository<Student>, IDisposable
    {
        Student GetById(string Id);
        bool Remove(string Id);
    }
}
