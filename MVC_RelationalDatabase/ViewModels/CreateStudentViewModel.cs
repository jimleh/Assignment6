using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC_RelationalDatabase.Models;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.ViewModels
{
    // This is probably unnecessary (and maybe even the wrong way to do it), but I just wanted to try using view models.
    public class CreateStudentViewModel
    {
        public int StudentID { get; set; }
        [Required, Display(Name = "Name:")]
        public string StudentName { get; set; }
        [Required, Display(Name = "Class:")]
        public int ClassID { get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; }

        public Student ToStudent()
        {
            return new Student
            {
                StudentID = this.StudentID,
                StudentName = this.StudentName,
                ClassID = this.ClassID
            };
        }
    }
}