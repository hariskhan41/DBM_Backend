using System;
using System.Collections.Generic;

namespace DBM.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Announcement = new HashSet<Announcement>();
            Assignments = new HashSet<Assignments>();
            CourseContent = new HashSet<CourseContent>();
            Lectures = new HashSet<Lectures>();
            Notes = new HashSet<Notes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public int InstituteId { get; set; }
        public int TeacherId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual Users Teacher { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<Announcement> Announcement { get; set; }
        public virtual ICollection<Assignments> Assignments { get; set; }
        public virtual ICollection<CourseContent> CourseContent { get; set; }
        public virtual ICollection<Lectures> Lectures { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
    }
}
