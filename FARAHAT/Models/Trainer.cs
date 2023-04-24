using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FARAHAT.Models
{
    public class Trainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }
        [DataType(dataType: DataType.EmailAddress)]
       [Required]
        public string Email { get; set; }
        public string Description { get; set; }
        [Url(ErrorMessage ="Please,write Email in correct format!")]
        public string Website { get; set; }
        public DateTime Creation_Date { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}