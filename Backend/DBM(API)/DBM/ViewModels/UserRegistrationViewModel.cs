using DBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBM.ViewModels
{
    public class UserRegistrationViewModel
    {
        //public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cnic { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Designation { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string InstituteName { get; set; }

        //public int LoginStatus { get; set; }

        //public int ActiveStatue { get; set; }

        //public int InstituteId { get; set; }


        public bool EmailAlreadyExists(string email, string designation)
        {
            DBMContext db = new DBMContext();
            Users u = db.Users.Where(u1 => (u1.Email == email && u1.Designation == designation)).FirstOrDefault();
            if (u != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
