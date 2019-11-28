using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBM.ViewModels
{
    public class CourseViewModel
    {
        public string Name { get; set; }

        public string CourseCode { get; set; }

        public int InstituteId { get; set; }

        //public int TeacherId { get; set; }

        public string CreatedBy { get; set; }

        public string CourseSession { get; set; }
        public string CourseSemester { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

    }
}
