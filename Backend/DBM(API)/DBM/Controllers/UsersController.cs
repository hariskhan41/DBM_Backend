using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Users/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] Users users)
        {
            users.InstituteId = 1;
            DBMContext db = new DBMContext();
            db.Users.Add(users);
            db.SaveChanges();
        }

        [HttpGet]
        public List<string> getInstitutes()
        {
            DBMContext db = new DBMContext();
            List<string> s = new List<string>();
            foreach (Institute i in db.Institute)
            {
                s.Add(i.Name);
            }
            return s;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
