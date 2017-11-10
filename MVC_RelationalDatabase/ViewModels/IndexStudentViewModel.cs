using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class IndexStudentViewModel
    {
        public int StudentID { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        [Display(Name = "Class")]
        public string ClassName { get; set; }
        [Display(Name = "Teachers")]
        public int NumberOfTeachers { get; set; }
    }
}