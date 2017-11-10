using System.ComponentModel.DataAnnotations;

namespace MVC_RelationalDatabase.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required, Display(Name = "Name:")]
        public string StudentName { get; set; }
        [Display(Name = "Email:")]
        public string StudentEmail { get; set; }
        [Display(Name = "Phone:")]
        public string StudentPhone { get; set; }
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
    }
}