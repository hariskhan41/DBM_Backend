using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBM.Models;
using DBM.ViewModels;
using System.Net;
using System.Net.Mail;

namespace DBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersRequestsController : ControllerBase
    {

        [HttpGet]
        [Route("Approve/{id}")]
        public void Approve(int id)
        {

        }

        // GET: api/UsersRequests
        // [HttpGet("GetAllStudentsRequests/{InstituteId}")]
        [HttpGet]
        [Route("GetAllStudentsRequests/{Id}")]
     
        public IEnumerable<StudentsRequestsViewModel> GetAllStudentsRequests(int Id)
        {
            //UsersRequestsViewModel u = new UsersRequestsViewModel();
            List<StudentsRequestsViewModel> lst = new List<StudentsRequestsViewModel>();
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            int InstId = db.Users.Where(b => b.Id == Id).FirstOrDefault().InstituteId;
            foreach (Users u in db.Users)
            {
               
                if (u.InstituteId == InstId && u.Designation == "Student" && u.LoginStatus == 0)
                {
                    StudentsRequestsViewModel usr = new StudentsRequestsViewModel();
                    usr.name = u.FirstName + ' ' + u.LastName;
                    usr.email = u.Email;
                    usr.id = u.Id;
                    lst.Add(usr);
                }
                
            }
            return lst;
        }

        [HttpGet]
        [Route("GetAllTeachersRequests/{Id}")]

        public IEnumerable<TeachersRequestViewModel> Get(int Id)
        {
            
            //UsersRequestsViewModel u = new UsersRequestsViewModel();
            List<TeachersRequestViewModel> lst = new List<TeachersRequestViewModel>();
            DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            int InstituteId = db.Users.Where(b => b.Id == Id).FirstOrDefault().InstituteId;
            foreach (Users u in db.Users)
            {
                
                if (u.InstituteId == InstituteId && u.Designation == "Teacher" && u.LoginStatus == 0)
                {
                    TeachersRequestViewModel user = new TeachersRequestViewModel();
                    user.Name = u.FirstName + ' ' + u.LastName;
                    user.Email = u.Email;
                    user.id = u.Id;
                    lst.Add(user);
                }
                
            }
            return lst;
        }

        public bool SendEmail(string Name, string Email)
        {

            try
            {
                // Credentials
                var credentials = new NetworkCredential("ayeshaatif7925@gmail.com", "Ayesha*8899");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("ayeshaatif7925@gmail.com"),
                    Subject = "LMS login Request",
                    Body = "your request is accepted successfully"
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(Email));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }

        }
    
    // POST: api/UsersRequests
        

        /*[HttpPost]
        [Route("ApproveTeacherRequest")]
        public IActionResult ApproveTeacherRequest([FromBody] TeachersRequestViewModel obj)
        {



            return Ok();
        }
        */
        // PUT: api/UsersRequests/5
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
