﻿using APIServer.DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIServer.Controllers
{
    public class ExampleController : ApiController
    {
        private Example repository;

        public ExampleController()
        {
            repository = new Example(new ModelContext ());
        }
        // GET: api/Example
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Example/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Example
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Example/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Example/5
        public void Delete(int id)
        {
        }
    }
}
