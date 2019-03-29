using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace APIServer.DAL
{
    public interface IAttendanceRepository:IRepository<Attendance>, IDisposable
    {
        Attendance GetById(int Id);
        bool Remove(int Id);
    }
}
