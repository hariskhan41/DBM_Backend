using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBM.ViewModels
{
    public class LectureViewModel
    {

        public string FilePath { get; set; }

        public string Title { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Email { get; set; }

        public string CourseName { get; set; }
        public int LectureId { get; set; }




    }
}
