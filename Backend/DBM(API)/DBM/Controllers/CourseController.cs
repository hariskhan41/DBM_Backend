using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBM.ViewModels;
using DBM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //// GET: api/Course
        //[HttpGet]
        //public IEnumerable<Courses> Get()
        //{
        //    DBMContext db = new DBMContext();
        //    return db.Courses.ToList();
        //}

        // GET: api/Course/5

        private UserManager<ApplicationUser> _userManager;

        public async Task<string> GetCurrentUserAsync()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return user.Email;

        }
        // POST: api/Course
        [HttpPost]
        public IActionResult Post([FromBody] CourseViewModel course)
        {

            // DBMContext db = new DBMContext();
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            Courses c = new Courses();
            if (db.Courses.Any(b => b.Name == course.Name && b.CourseCode == course.CourseCode))
            {
                int year = db.CourseInfo.Where(b => b.Courseid == db.Courses.Where(r=> r.Name == course.Name).FirstOrDefault().Id).FirstOrDefault().CourseYear;
                if (year == Int32.Parse(course.CourseSession))
                {
                    ModelState.AddModelError("", "Course already exists");
                    return BadRequest(ModelState);
                }
            }
            c.CourseCode = course.CourseCode;
            c.Name = course.Name;
            // c.InstituteId = db.Users.Where(b => b.Email == GetCurrentUserAsync().ToString()).FirstOrDefault().InstituteId;
            c.InstituteId = 1;
            c.ParentCourseid = null;
            db.Courses.Add(c);
            db.SaveChanges();
            CourseInfo cd = new CourseInfo();
            cd.CreatedOn = DateTime.Now;
            // cd.CreatedBy = db.Users.Where(b => b.Email == GetCurrentUserAsync().ToString()).FirstOrDefault().Id;
            cd.CreatedBy = 1;
            cd.UpdatedOn = DateTime.Now;
            cd.UpdatedBy = 1;
            cd.CourseSemester = course.CourseSemester;
            cd.CourseYear = Int32.Parse(course.CourseSession);
            cd.Courseid = db.Courses.Where(b => b.Name == course.Name).FirstOrDefault().Id;
            
            db.CourseInfo.Add(cd);
            db.SaveChanges();
            return Ok();
           
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseViewModel course)
        {
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            //DBMContext db = new DBMContext();
            int courseId = db.CourseInfo.Where(b => b.Id == id).FirstOrDefault().Courseid;
            if (db.Courses.Any(b => b.Name == course.Name && b.CourseCode == course.CourseCode))
            {
                int year = db.CourseInfo.Where(b => b.Courseid == db.Courses.Where(r => r.Name == course.Name).FirstOrDefault().Id).FirstOrDefault().CourseYear;
                if (year == Int32.Parse(course.CourseSession))
                {
                    ModelState.AddModelError("", "Course already exists");
                    return BadRequest(ModelState);
                }
            }
            db.Courses.Where(b => b.Id == courseId).SingleOrDefault().CourseCode = course.CourseCode;
            db.Courses.Where(b => b.Id == courseId).SingleOrDefault().Name =course.Name;
            db.CourseInfo.Where(b => b.Id == id).SingleOrDefault().UpdatedOn = DateTime.Now;
          //  db.CourseInfo.Where(b => b.Id == id).SingleOrDefault().UpdatedBy = db.Users.Where(b => b.Email == GetCurrentUserAsync().ToString()).FirstOrDefault().Id
            db.CourseInfo.Where(b => b.Id == id).SingleOrDefault().UpdatedBy = 1;
            db.CourseInfo.Where(b => b.Id == id).SingleOrDefault().CourseSemester = course.CourseSemester;
            db.CourseInfo.Where(b => b.Id == id).SingleOrDefault().CourseYear =Int32.Parse(course.CourseSession);
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
