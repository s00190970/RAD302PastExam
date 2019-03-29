using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace APIServer.DAL
{
    public class Example : IStudentRepository
    {
        private ModelContext context;
        public Example(ModelContext cont)
        {
            context = cont;
        }
        public Student Add(Student item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Edit(Student item)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string Id)
        {
            throw new NotImplementedException();
        }
    }
}