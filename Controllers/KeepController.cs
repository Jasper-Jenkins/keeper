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
   
    [Route("api/[controller]")]
      
    public class KeepController : ControllerBase
    {
        private readonly KeepRepository _db;
                // GET api/values
        public KeepController(KeepRepository repo)
        {
            _db = repo;
        }
        
        [HttpGet]
        public IEnumerable<Keep> GetUserKeeps()
        {
            return _db.GetAll();
        }

         // GET api/vault/:id
        [HttpGet("vault/{id}")]
        public IEnumerable<Keep> Get(int id)
        {
           return _db.GetbyVaultId(id);
        }

        [HttpGet("{id}")]
        public Keep GetbyKeepId(int id)
        {
           return _db.GetbyKeepId(id);
        }

        // [HttpGet("/vaultkeeps/{id}")]
        // public IEnumerable<Keep> GetbyKeepId1(int id)
        // {
        //    return _db.GetbyKeepId1(id);
        // }
        [HttpGet("author")]
        public IEnumerable<Keep> Get()
        {
         var user = HttpContext.User;
         var Id = user.Identity.Name;
         return _db.GetbyAuthorId(Id);
        }

        // POST api/keep/:
        [HttpPost]
        public Keep CreateKeep([FromBody]Keep newKeep)
        {
            var user = HttpContext.User;
            newKeep.AuthorId = user.Identity.Name;
            
            if (ModelState.IsValid)
            {
                 return _db.CreateKeep(newKeep);
            }
            return null;
        }

     //   PUT api/user/5
        [HttpPut("user/{id}")]
        public Keep Put(int id, [FromBody]Keep value) // 
        {
             return _db.EditKeep(id, value);
        }

        // DELETE api/
        [HttpDelete]
        public void Delete([FromBody]Keep value)
        {
           _db.DeleteKeep(value.Id);
        }
    }
}
