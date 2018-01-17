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
    public class VaultsController : Controller
    {
        private readonly VaultRepository db;
        public VaultsController(VaultRepository vaultRepo)
        {
            db = vaultRepo;
        }

        // GET api/values
        // [HttpGet]
        // public IEnumerable<Vault> Get()
        // {
        //     return db.GetAll();
        // }

        [Authorize]
        [HttpGet("{userId}")]
        public IEnumerable<Vault> GetUserVaults(int userId)
        {
            return db.GetUserVaults(userId);
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public Vault Get(int id)
        // {
        //     return db.GetById(id);
        // }

        // POST api/values
        [Authorize]
        [HttpPost]
        public Vault Post([FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return db.Add(vault);
            }
            return null;
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, vault);
            }
            return null;
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{vaultId}")]
        public string Delete(int vaultId)
        {
            return db.FindByIdAndRemove(vaultId);
        }
    }
}