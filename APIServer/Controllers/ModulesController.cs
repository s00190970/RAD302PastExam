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
    [RoutePrefix("api/Modules")]
    public class ModulesController : ApiController
    {
        private IModuleRepository repository;

        public ModulesController()
        {
            repository = new ModuleRepository(new ModelContext());
        }

        // GET: api/Modules
        [Route("")]
        [HttpGet]
        public List<Module> GetModules()
        {
            return repository.GetAll();
        }

        // GET: api/Modules/5
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Module))]
        public IHttpActionResult GetModule(int id)
        {
            Module module = repository.GetById(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/Modules
        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Module))]
        public IHttpActionResult PutModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            module = repository.Add(module);

            return Content(HttpStatusCode.OK, module);
        }

        // POST: api/Modules/5
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Attendance))]
        public IHttpActionResult PostModule(int id, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != module.ID)
            {
                return BadRequest();
            }

            bool result = repository.Edit(module);

            if (!result)
            {
                return BadRequest();
            }

            module = repository.GetById(id);
            return Content(HttpStatusCode.OK, module);
        }

        // DELETE: api/Modules/5
        [Route("")]
        [HttpDelete]
        [ResponseType(typeof(Module))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module module = repository.GetById(id);
            bool result = repository.Remove(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(module);
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