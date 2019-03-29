using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIServer.DAL;
using Models;

namespace APIServer.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        private IStudentRepository repository;

        public StudentsController()
        {
            repository = new StudentRepository(new ModelContext());
        }

        // GET: api/Students
        [HttpGet]
        [Route("")]
        public List<Student> GetStudents()
        {
            return repository.GetAll();
        }

        // GET: api/Students/5
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(string id)
        {
            Student student = repository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students
        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PutStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            student = repository.Add(student);

            return Content(HttpStatusCode.OK, student);
        }

        // POST: api/Students/5
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentID)
            {
                return BadRequest();
            }

            bool result = repository.Edit(student);

            if (!result)
            {
                return BadRequest();
            }

            student = repository.GetById(id);
            return Content(HttpStatusCode.OK, student);
        }

        // DELETE: api/Students/5
        [Route("")]
        [HttpDelete]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(string id)
        {
            Student student = repository.GetById(id);
            bool result = repository.Remove(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}