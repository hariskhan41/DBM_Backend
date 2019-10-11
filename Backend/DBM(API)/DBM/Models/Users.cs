using System;
using System.Collections.Generic;

namespace DBM.Models
{
    public partial class Users
    {
        public Users()
        {
            AnnouncementCreatedByNavigation = new HashSet<Announcement>();
            AnnouncementUpdatedByNavigation = new HashSet<Announcement>();
            AssignmentsCreatedByNavigation = new HashSet<Assignments>();
            AssignmentsUpdatedByNavigation = new HashSet<Assignments>();
            CourseContentAddedByNavigation = new HashSet<CourseContent>();
            CourseContentUpdatedByNavigation = new HashSet<CourseContent>();
            CoursesCreatedByNavigation = new HashSet<Courses>();
            CoursesTeacher = new HashSet<Courses>();
            CoursesUpdatedByNavigation = new HashSet<Courses>();
            NotesCreatedByNavigation = new HashSet<Notes>();
            NotesUpdatedByNavigation = new HashSet<Notes>();
            UserAssignedGroups = new HashSet<UserAssignedGroups>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cnic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int LoginStatus { get; set; }
        public int ActiveStatue { get; set; }
        public int InstituteId { get; set; }

        public virtual Institute Institute { get; set; }
        public virtual ICollection<Announcement> AnnouncementCreatedByNavigation { get; set; }
        public virtual ICollection<Announcement> AnnouncementUpdatedByNavigation { get; set; }
        public virtual ICollection<Assignments> AssignmentsCreatedByNavigation { get; set; }
        public virtual ICollection<Assignments> AssignmentsUpdatedByNavigation { get; set; }
        public virtual ICollection<CourseContent> CourseContentAddedByNavigation { get; set; }
        public virtual ICollection<CourseContent> CourseContentUpdatedByNavigation { get; set; }
        public virtual ICollection<Courses> CoursesCreatedByNavigation { get; set; }
        public virtual ICollection<Courses> CoursesTeacher { get; set; }
        public virtual ICollection<Courses> CoursesUpdatedByNavigation { get; set; }
        public virtual ICollection<Notes> NotesCreatedByNavigation { get; set; }
        public virtual ICollection<Notes> NotesUpdatedByNavigation { get; set; }
        public virtual ICollection<UserAssignedGroups> UserAssignedGroups { get; set; }
    }
}
