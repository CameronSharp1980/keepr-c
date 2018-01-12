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
    public class VaultKeepsController : Controller
    {
        private readonly VaultKeepRepository db;
        public VaultKeepsController(VaultKeepRepository vaultKeepRepo)
        {
            db = vaultKeepRepo;
        }

        // GET api/values        
        // [HttpGet]
        // public IEnumerable<VaultKeep> Get()
        // {
        //     return db.GetAll();
        // }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public VaultKeep Get(int id)
        // {
        //     return db.GetById(id);
        // }

        [HttpGet("{vaultid}")]
        public IEnumerable<VaultKeepReturnModel> GetKeeps(int vaultid)
        {
            return db.GetKeeps(vaultid);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public VaultKeep Post([FromBody]VaultKeep vaultKeep)
        {
            if (ModelState.IsValid)
            {
                return db.Add(vaultKeep);
            }
            return null;
        }

        // PUT api/values/5
        // [Authorize]
        // [HttpPut("{id}")]
        // public VaultKeep Put(int id, [FromBody]VaultKeep vaultKeep)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         return db.GetOneByIdAndUpdate(id, vaultKeep);
        //     }
        //     return null;
        // }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}