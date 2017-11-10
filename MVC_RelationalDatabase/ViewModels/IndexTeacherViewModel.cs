using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class IndexTeacherViewModel
    {
        public int TeacherID { get; set; }
        [Display( Name = "Name")]
        public string TeacherName { get; set; }
        [Display(Name = "Classes")]
        public int NumberOfClasses { get; set; }
        [Display(Name = "Students")]
        public int NumberOfStudents { get; set; }
    }
}