using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TSCS2.Models
{
    public class CourseModel
    {
        public int CourseNo { get; set; }
        public int id { get; set; }

        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public string CourseTitle { get; set; }

    }
}