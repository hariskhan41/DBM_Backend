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
        public void Post([FromBody] UserRegistrationViewModel users)
        {
            //users.InstituteId = 1;
            DBMContext db = new DBMContext();
            Users u = new Users();
            u.FirstName = users.FirstName;
            u.LastName = users.LastName;
            u.Cnic = users.Cnic;
            u.Email = users.Email;
            u.Password = users.Password;
            u.DateOfBirth = users.DateOfBirth;
            u.Designation = users.Designation;
            u.LoginStatus = 0;
            u.ActiveStatue = 1;
            u.InstituteId = db.Institute.Where(p => p.Name.Equals(users.InstituteName)).FirstOrDefault().Id;
            db.Users.Add(u);
            //db.Users.Add(users);
            db.SaveChanges();
        }

        //[HttpGet]
        //public List<string> getInstitutes()
        //{
        //    DBMContext db = new DBMContext();
        //    List<string> s = new List<string>();
        //    foreach (Institute i in db.Institute)
        //    {
        //        s.Add(i.Name);
        //    }
        //    return s;
        //}

        [HttpGet]
        public IEnumerable<Institute> get()
        {
            List<Institute> institutes = new List<Institute>();
            DBMContext db = new DBMContext();
            foreach (Institute i in db.Institute)
            {
                institutes.Add(i);
            }
            return institutes;
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
