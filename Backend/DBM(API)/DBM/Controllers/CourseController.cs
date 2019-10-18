using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBM.ViewModels;
using DBM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // GET: api/Course
        [HttpGet]
        public IEnumerable<Courses> Get()
        {
            DBMContext db = new DBMContext();
            return db.Courses.ToList();
        }

        // GET: api/Course/5
        

        // POST: api/Course
        [HttpPost]
        public IActionResult Post([FromBody] CourseViewModel course)
        {

            DBMContext db = new DBMContext();
            Courses c = new Courses();
            if(db.Courses.Any(b=>b.Name == course.Name && b.CourseCode == course.CourseCode))
            {
                ModelState.AddModelError("", "Course already exists");
                return BadRequest(ModelState);
            }
            c.Name = course.Name;
            c.UpdatedOn = DateTime.Now;
            c.CreatedOn = DateTime.Now;
            c.TeacherId = 1;
            c.InstituteId = 1;
            c.UpdatedBy = 1;
            c.CreatedBy = 1;
            c.CourseCode = course.CourseCode;
            db.Courses.Add(c);
            db.SaveChanges();
            return Ok();
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseViewModel value)
        {
            DBMContext db = new DBMContext();
            if (db.Courses.Where(b=>b.Id == id).Any(b => b.Name == value.Name && b.CourseCode == value.CourseCode))
            {
                ModelState.AddModelError("", "Course already exists");
                return BadRequest(ModelState);
            }
            db.Courses.Where(b => b.Id == id).SingleOrDefault().CourseCode = value.CourseCode;
            db.Courses.Where(b => b.Id == id).SingleOrDefault().Name = value.Name;
            db.Courses.Where(b => b.Id == id).SingleOrDefault().UpdatedOn = DateTime.Now;
            db.Courses.Where(b => b.Id == id).SingleOrDefault().UpdatedBy = 1;
            db.SaveChanges();
            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
