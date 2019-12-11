using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBM.ViewModels
{
    public class AnnouncementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CourseId { get; set; }

    }
}
