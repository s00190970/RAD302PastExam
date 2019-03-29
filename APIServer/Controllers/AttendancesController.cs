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
    [RoutePrefix("api/Attendances")]
    public class AttendancesController : ApiController
    {
        private IAttendanceRepository repository;

        public AttendancesController()
        {
            repository = new AttendanceRepository(new ModelContext());
        }

        // GET: api/Attendances
        [Route("")]
        [HttpGet]
        public List<Attendance> GetAttendances()
        {
            return repository.GetAll();
        }

        // GET: api/Attendances/5
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Attendance))]
        public IHttpActionResult GetAttendance(int id)
        {
            Attendance attendance = repository.GetById(id);
            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
        }

        // PUT: api/Attendances
        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Attendance))]
        public IHttpActionResult PutAttendance(Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            attendance = repository.Add(attendance);

            return Content(HttpStatusCode.OK, attendance);
        }

        // POST: api/Attendances/5
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Attendance))]
        public IHttpActionResult PostAttendance(int id, Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendance.ID)
            {
                return BadRequest();
            }

            bool result = repository.Edit(attendance);

            if (!result)
            {
                return BadRequest();
            }

            attendance = repository.GetById(id);

            return Content(HttpStatusCode.OK, attendance);
        }

        // DELETE: api/Attendances/5
        [Route("")]
        [HttpDelete]
        [ResponseType(typeof(Attendance))]
        public IHttpActionResult DeleteAttendance(int id)
        {
            Attendance attendance = repository.GetById(id);
            bool result = repository.Remove(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(attendance);
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