using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr_c.Models;
using keepr_c.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace keepr_c.Controllers
{
    [Route("api/[controller]")]
    public class KeepController : Controller
    {
        private readonly KeepRepository db;
        public KeepController(KeepRepository keepRepo)
        {
            db = keepRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return db.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Keep Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public Keep Post([FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return db.Add(keep);
            }
            return null;
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, keep);
            }
            return null;
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}