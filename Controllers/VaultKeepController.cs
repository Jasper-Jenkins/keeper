using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API_Users.Models;
using API_Users.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Users.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
      
    public class VaultKeepController : ControllerBase
    {
        private readonly VaultKeepRepository _db;
                // GET api/values
        public VaultKeepController(VaultKeepRepository repo)
        {
            _db = repo;
        }
        
        // [HttpGet]
        // public IEnumerable<VaultKeep> GetUserVaultKeeps()
        // {
        //     return _db.GetAll();
        // }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //    return _db.GetbyVaultKeepId(id);
        // }

        [HttpGet("{id}")]
        public VaultKeep Get(int id)
        {
           return _db.GetbyVaultKeepId(id);
        }

        [HttpGet]
        public IEnumerable<VaultKeep> Get()
        {
         var user = HttpContext.User;
         var Id = user.Identity.Name;
         return _db.GetbyAuthorId(Id);
        }

        // POST api/keep/
        [HttpPost("{id}")]
        public VaultKeep CreateVaultKeep(int id, [FromBody]VaultKeep newVaultKeep)
        {
            var user = HttpContext.User;
            newVaultKeep.AuthorId = user.Identity.Name;
            newVaultKeep.VaultId = id;
            if (ModelState.IsValid)
            {
                 return _db.CreateVaultKeep(newVaultKeep);
            }
            return null;
        }

     //   PUT api/user/5
        [HttpPut("user/{id}")]
        public VaultKeep Put(int id, [FromBody]VaultKeep value) // 
        {
             return _db.EditVaultKeep(id, value);
        }

        // DELETE api/
        [HttpDelete]
        public void Delete([FromBody]VaultKeep value)
        {
           _db.DeleteVaultKeep(value.Id);
        }
    }
}
