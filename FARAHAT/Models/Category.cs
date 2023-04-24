using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FARAHAT.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Parent ID")]
        public int? parent_ID { get; set; }
        public string parent_Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        [Display(Name = "Image")]
        public string Image_ID { get; set; }
    }
}