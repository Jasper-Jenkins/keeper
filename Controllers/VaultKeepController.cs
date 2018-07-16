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

        // /api/vaultkeep/:id
        [HttpGet("{id}")]
        public IEnumerable<VaultKeep> Get(int id)
        {
           return _db.GetbyVaultId(id);
        }
        // /api/vaultkeep
        [HttpGet]
        public IEnumerable<VaultKeep> GetbyAuthorId()
        {
         var user = HttpContext.User;
         var Id = user.Identity.Name;

         return _db.GetbyAuthorId(Id);
        }
     //   /api/vaultkeeps/keeps   accessing 
        // [HttpGet("/keeps")]
        // public IEnumerable<Keep> GetKeepsforVault([FromBody]VaultKeep vaultKeeps)
        // {
        //  var user = HttpContext.User;
        //  var Id = user.Identity.Name;

        //  return _db.GetKeepsforVaultKeepsKeepId(vaultKeeps);
        // }

        // POST api/vaultkeep/{keepId}
        [HttpPost("{keepId}")]
        public VaultKeep CreateVaultKeep(int keepId, [FromBody]VaultKeep newVaultKeep)
        {
            var user = HttpContext.User;
          //  newVaultKeep.AuthorId = user.Identity.Name;
            newVaultKeep.KeepId = keepId;
           
            if (ModelState.IsValid)
            {
                 return _db.CreateVaultKeep(newVaultKeep, keepId);
            }
            return null;
        }

     //   PUT api/user/5
        [HttpPut("user/{id}")]
        public VaultKeep Put(int id, [FromBody]VaultKeep value) // 
        {
             return _db.EditVaultKeep(id, value);
        }

        // DELETE api/vaultkeep/delete/{vaultId}/{keepId}
        [HttpDelete("delete/{vaultId}/{keepId}")]
        public void DeleteVaultKeep(int vaultId, int keepId)
        {
            var user = HttpContext.User.Identity.Name;
           _db.DeleteVaultKeep(vaultId, keepId, user);
        }
    }
}
