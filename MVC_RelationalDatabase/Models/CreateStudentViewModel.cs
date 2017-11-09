using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Models
{
    // This is probably unnecessary (and maybe even the wrong way to do it), but I just wanted to try using view models.
    public class CreateStudentViewModel
    {
        public int StudentID { get; set; }
        [Required, DisplayName("Name")]
        public string StudentName { get; set; }
        [Required, DisplayName("Class")]
        public int ClassID { get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; }

        public Student ToStudent()
        {
            return new Student { StudentID = this.StudentID, StudentName = this.StudentName, ClassID = this.ClassID };
        }
    }
}