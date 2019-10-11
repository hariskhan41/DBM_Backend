using System;
using System.Collections.Generic;

namespace DBM.Models
{
    public partial class Lectures
    {
        public int Id { get; set; }
        public int Tite { get; set; }
        public string LectureFilePath { get; set; }
        public int CourseId { get; set; }

        public virtual Courses Course { get; set; }
    }
}
