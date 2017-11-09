using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Models
{
    public class EditStudentViewModel
    {
        public Student Student {get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; }

        public EditStudentViewModel() {}

        public EditStudentViewModel(Student student)
        {
            Student = student;
        }

        public Student ToStudent()
        {
            return Student;
        }
    }
}