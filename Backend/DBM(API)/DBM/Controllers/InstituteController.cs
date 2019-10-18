using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBM.Models;
using DBM.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        // GET: api/Institute
        [HttpGet]
        public IEnumerable<Institute> Get()
        {
            List<Institute> institutes = new List<Institute>();
            DBMContext db = new DBMContext();
            institutes = db.Institute.ToList();
            return institutes;  
        }

      

        // GET: api/Institute/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Institute
        [HttpPost]
        public IActionResult Post([FromBody] InstitutesViewModel institute)
        {

            DBMContext db = new DBMContext();
            Institute i = new Institute();
            if(db.Institute.Any(b=>b.Name == institute.name))
            {
                ModelState.AddModelError("", "This Institute already exists");
                return BadRequest(ModelState);
            }
            i.Name = institute.name;
            db.Institute.Add(i);
            db.SaveChanges();
            return Ok();
        }

        // PUT: api/Institute/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InstitutesViewModel institutes)
        {
            DBMContext db = new DBMContext();
            if(db.Institute.Any(b=>b.Name == institutes.name))
            {
                ModelState.AddModelError("", "This Institute already exists");
                return BadRequest(ModelState);
            }
            db.Institute.Where(b => b.Id == id).FirstOrDefault().Name = institutes.name;
            db.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DBMContext db = new DBMContext();
            if(!db.Institute.Any(b=>b.Id == id))
            {
                ModelState.AddModelError("", "Institute at this id doesn't exist");
                return BadRequest(ModelState);
            }
            Institute i = db.Institute.Single(b => b.Id == id);
            db.Institute.Remove(i);
            db.SaveChanges();
            return Ok();
        }
    }
}
