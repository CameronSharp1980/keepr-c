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
    public class KeepsController : Controller
    {
        private readonly KeepRepository db;
        public KeepsController(KeepRepository keepRepo)
        {
            db = keepRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return db.GetAll();
        }
        [Authorize]
        [HttpGet("{userId}")]
        public IEnumerable<Keep> GetUserKeeps(int userId)
        {
            return db.GetUserKeeps(userId);
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public Keep Get(int id)
        // {
        //     return db.GetById(id);
        // }

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

        [HttpPut("{keepId}/views")]
        public Keep IncrementViews([FromBody] Keep keep)
        {
            if (ModelState.IsValid)
            {
                return db.IncrementViews(keep);
            }
            return null;
        }
        // api.put(`keeps/${payload.keep.id}/views/${payload.keep.views}`)

        [HttpPut("{keepId}/keeps")]
        public Keep IncrementKeeps([FromBody] Keep keep)
        {
            if (ModelState.IsValid)
            {
                return db.IncrementKeeps(keep);
            }
            return null;
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{keepId}")]
        public string Delete(int keepId)
        {
            return db.FindByIdAndRemove(keepId);
        }
    }
}