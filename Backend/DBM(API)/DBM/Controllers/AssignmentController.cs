using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBM.Models;
using DBM.ViewModels;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Hosting;

using System.IO;
using System.Net.Http.Headers;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {

        private IHostingEnvironment _hostingEnvironment;
        public AssignmentController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Assignment

        [HttpGet]
        public IEnumerable<AssignmentsViewModel> Get()
        {
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            List<AssignmentsViewModel> lst = new List<AssignmentsViewModel>();
            foreach(Assignments s in db.Assignments)
            {
                AssignmentsViewModel a = new AssignmentsViewModel();
                a.Title = s.Title;
                a.CreatedBy = db.Users.Where(b => b.Id == s.CreatedBy).FirstOrDefault().FirstName + " " + db.Users.Where(b => b.Id == s.CreatedBy).FirstOrDefault().LastName;
                a.UpdatedBy = db.Users.Where(b => b.Id == s.UpdatedBy).FirstOrDefault().FirstName + " " + db.Users.Where(b => b.Id == s.UpdatedBy).FirstOrDefault().LastName;
                a.SubmissionDateTime = s.SubmissionDateTime;
                a.StartDateTime = s.StartDateTime;
                a.PostSubmissionDateTime = s.PostSubmissionDateTime;
                a.Status = s.Status;
                lst.Add(a);
            }

            return lst.ToList();
           //return new string[] { "value1", "value2" };
        }

        //// GET: api/Assignment/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        private UserManager<ApplicationUser> _userManager;

        public async Task<string> GetCurrentUserAsync()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return user.Email;

        }
        // POST: api/Assignment
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromBody] AssignmentsViewModel val)
        {
            
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            Assignments ass = new Assignments();

            ass.Title = val.Title;
            //ass.FilePath = val.FilePath;
            ass.SubmissionDateTime = val.SubmissionDateTime;
            ass.StartDateTime = val.StartDateTime;
            ass.Status = "Not Submitted";
            ass.PostSubmissionDateTime = val.SubmissionDateTime;
            ass.CreatedBy = 1;
            ass.UpdatedBy = 1;
            ass.CreatedOn = DateTime.Now;
            ass.UpdatedOn = DateTime.Now;
            ass.CourseId = 3;
            db.Assignments.Add(ass);
            

            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                db.SaveChanges();
                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }
            var file = Request.Form.Files[0];
            var folderName = "Resources";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            ass.Title = val.Title;
            ass.FilePath = file.ToString();
            ass.SubmissionDateTime = val.SubmissionDateTime;
            ass.StartDateTime = val.StartDateTime;
            ass.Status = "Not Submitted";
            ass.PostSubmissionDateTime = val.SubmissionDateTime;
            // cd.CreatedBy = db.Users.Where(b => b.Email == GetCurrentUserAsync().ToString()).FirstOrDefault().Id;
            // cd.UpdatedBy = db.Users.Where(b => b.Email == GetCurrentUserAsync().ToString()).FirstOrDefault().Id;
            ass.CreatedBy = 1;
            ass.UpdatedBy = 1;
            ass.CreatedOn = DateTime.Now;
            ass.UpdatedOn = DateTime.Now;
            ass.CourseId = 3;
            db.Assignments.Add(ass);
            db.SaveChanges();
            return Ok();
        }
         
        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AssignmentsViewModel val)
        {
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            if (db.Assignments.Any(b => b.Title == val.Title && b.FilePath == val.FilePath))
            {
                ModelState.AddModelError("UniqueAssignment", "This assignment already exists");
                return BadRequest(ModelState);
            }
            else if (val.SubmissionDateTime < DateTime.Now)
            {
                ModelState.AddModelError("", "Enter valid Submission Date");
                return BadRequest(ModelState);
            }
            else if (val.StartDateTime < DateTime.Now)
            {
                ModelState.AddModelError("", "Enter valid Submission Date");
                return BadRequest(ModelState);
            }
            db.Assignments.Where(b => b.Id == id).FirstOrDefault().Title = val.Title;
            db.Assignments.Where(b => b.Id == id).FirstOrDefault().FilePath = val.FilePath;
            db.Assignments.Where(b => b.Id == id).FirstOrDefault().PostSubmissionDateTime = val.PostSubmissionDateTime;
            db.Assignments.Where(b => b.Id == id).FirstOrDefault().SubmissionDateTime = val.SubmissionDateTime;
            db.Assignments.Where(b => b.Id == id).FirstOrDefault().UpdatedOn = DateTime.Now;
            db.Assignments.Where(b => b.Id == id).FirstOrDefault().UpdatedBy = 1;
            // cd.UpdatedBy = db.Users.Where(b => b.Email == GetCurrentUserAsync().ToString()).FirstOrDefault().Id;
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
