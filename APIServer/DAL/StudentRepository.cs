using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;

namespace APIServer.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private ModelContext context;

        public StudentRepository(ModelContext context)
        {
            this.context = context;
        }
        public StudentRepository() { }

        public void Dispose()
        {
            context.Dispose();;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(string Id)
        {
            return context.Students.FirstOrDefault(s => s.StudentID.Equals(Id));
        }

        public Student Add(Student item)
        {
            Student addedStudent=context.Students.Add(item);
            context.SaveChanges();
            return addedStudent;
        }

        public bool Remove(string Id)
        {
            Student student = GetById(Id);
            if (student == null)
            {
                return false;
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return true;
        }

        public bool Edit(Student item)
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
    }
}