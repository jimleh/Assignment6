using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        [Required, DisplayName("Name")]
        public string TeacherName { get; set; }
        [DisplayName("Email")]
        public string TeacherEmail { get; set; }
        [DisplayName("Phone")]
        public string TeacherPhone { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}