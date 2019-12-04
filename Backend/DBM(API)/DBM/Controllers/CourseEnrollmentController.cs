using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBM.Models;
using DBM.ViewModels;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        // GET: api/CourseEnrollment
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/CourseEnrollment/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/CourseEnrollment
        [HttpPost]
        [Route("EnrolmentPending")]
        public IActionResult Post([FromBody]CourseViewModel course)
        {
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            CourseEnrollment c = new CourseEnrollment();
            c.CourseId = db.Courses.Where(b => b.CourseCode == course.courseCode).FirstOrDefault().Id;
            c.UserId = course.UserId;
            c.EnrollmentStatus = "Pending";
            db.Add(c);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("Approve")]
        public IActionResult ApproveRequest([FromBody]CourseEnrollment course)
        {
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            db.CourseEnrollment.Where(b => b.Id == course.Id).FirstOrDefault().EnrollmentStatus = "Approved";
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("Disapprove")]
        public IActionResult DisApproveRequest([FromBody]CourseEnrollment course)
        {
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            if (!db.CourseEnrollment.Any(b => b.Id ==course.Id))
            {
                ModelState.AddModelError("", "Enrollment request at this id doesn't exist");
                return BadRequest(ModelState);
            }
            CourseEnrollment i = db.CourseEnrollment.Single(b => b.Id == course.Id);
            db.CourseEnrollment.Remove(i);
            db.SaveChanges();
            return Ok();
        }
        //[MultiPostParameters]
        [HttpGet("{UserId}/{CourseName}")]
        
        public IEnumerable<CourseEnrollmentViewModel> GetCourseEnrollments(int UserId, string CourseName)
        {
            List<CourseEnrollmentViewModel> courseLst = new List<CourseEnrollmentViewModel>();
            //List<CourseEnrollment> courseLst = new List<CourseEnrollment>();
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
         
            if(db.Users.Where(b=>b.Id==UserId).FirstOrDefault().Designation=="Teacher")
            {
                foreach (CourseEnrollment e in db.CourseEnrollment)
                {
                    if (e.CourseId == db.Courses.Where(b => b.Name == CourseName).FirstOrDefault().Id)
                    {
                        CourseEnrollmentViewModel c = new CourseEnrollmentViewModel();
                        c.Email = db.Users.Where(b => b.Id == e.UserId).FirstOrDefault().Email;
                        c.UserName = db.Users.Where(b => b.Id == e.UserId).FirstOrDefault().FirstName + " " + db.Users.Where(b => b.Id == e.UserId).FirstOrDefault().LastName;
                        courseLst.Add(c);

                    }
                }
            }
            
            return courseLst;
        }


        // PUT: api/CourseEnrollment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] CourseEnrollmentViewModel course)
        //{

        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
