using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FARAHAT.Models
{
    public class CourseLesson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string Title { get; set; }

        public int? OrderNember { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Course")]
        public int course_ID { get; set; }
    }
}