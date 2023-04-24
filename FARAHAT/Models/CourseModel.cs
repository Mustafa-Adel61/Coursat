using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FARAHAT.Models
{
    //كنت عامله عشان احفظ بيه الصوره عامل فيه ImageFile مخصوص لكن دلوقت مش مستخدمه
    public class CourseModel
    {
        //عشان العلاقه many to many
        public CourseModel()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        [Required]

        public int category_ID { get; set; }

        public virtual Trainer Trainer { get; set; }
        [ForeignKey("Trainer")]
        [Display(Name = "Trainer")]
        [Required]
        public int trainer_ID { get; set; }
        public virtual ICollection<CourseLesson> CourseLessons { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        [Display(Name = "Trainer Name")]
        public string TrainerName { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string picture_ID { get; set; }
        [Required]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}