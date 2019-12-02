using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBM.ViewModels
{
    public class AssignmentsViewModel
    {
        //public int Id { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public DateTime SubmissionDateTime { get; set; }
        public DateTime PostSubmissionDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CourseName { get; set; }
       // public int CourseId { get; set; }

    }
}
