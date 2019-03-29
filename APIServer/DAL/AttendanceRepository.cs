using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;

namespace APIServer.DAL
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ModelContext context;

        public AttendanceRepository(ModelContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public bool Edit(Attendance item)
        {
            try
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public List<Attendance> GetAll()
        {
            return context.Attendances.ToList();
        }

        public Attendance GetById(int Id)
        {
            return context.Attendances.FirstOrDefault(a => a.ID == Id);
        }

        public Attendance Add(Attendance item)
        {
            Attendance addedAttendance = context.Attendances.Add(item);
            context.SaveChanges();
            return addedAttendance;
        }

        public bool Remove(int Id)
        {
            Attendance attendance = GetById(Id);
            if (attendance == null)
            {
                return false;
            }

            context.Attendances.Remove(attendance);
            context.SaveChanges();
            return true;
        }
    }
}