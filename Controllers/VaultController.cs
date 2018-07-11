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
      
    public class VaultController : ControllerBase
    {
        private readonly VaultRepository _db;
                // GET api/values
        public VaultController(VaultRepository repo)
        {
            _db = repo;
        }
        
        // [HttpGet]
        // public IEnumerable<Vault> GetUserVaults()
        // {
        //     return _db.GetAll();
        // }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //    return _db.GetbyVaultId(id);
        // }

        [HttpGet("{id}")]
        public Vault Get(int id)
        {
           return _db.GetbyVaultId(id);
        }

        [HttpGet]
        public IEnumerable<Vault> Get()
        {
         var user = HttpContext.User;
         var Id = user.Identity.Name;
         return _db.GetbyAuthorId(Id);
        }

        // POST api/values
        [HttpPost]
        public Vault CreateVault([FromBody]Vault value)
        {
            var user = HttpContext.User;
            value.AuthorId = user.Identity.Name;
            
            if (ModelState.IsValid)
            {
                 return _db.CreateVault(value);
            }
            return null;
        }

        // PUT api/values/5
        // [HttpPut("user/{id}")]
        // public IEnumerable<Vault> Put(int id, [FromBody]Vault value)
        // {
        // // return _db.GetbyAuthorId(id);
        // }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete([FromBody]Vault value)
        {

            _db.DeleteVault(value.Id);
        }
    }
}
