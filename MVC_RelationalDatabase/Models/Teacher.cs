using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_RelationalDatabase.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        [Required, Display(Name = "Name:")]
        public string TeacherName { get; set; }
        [Display(Name = "Email:")]
        public string TeacherEmail { get; set; }
        [Display(Name = "Phone:")]
        public string TeacherPhone { get; set; }

        public Teacher()
        {
            Classes = new List<Class>();
        }

        public virtual ICollection<Class> Classes { get; set; }
    }
}