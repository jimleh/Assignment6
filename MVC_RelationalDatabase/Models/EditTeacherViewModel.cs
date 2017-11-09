using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class EditTeacherViewModel
    {
        public Teacher Teacher { get; set; }

        public IEnumerable<Class> Classes { get; set; }
        public bool[] Selected { get; set; }

        public EditTeacherViewModel() {}

        public EditTeacherViewModel(Teacher teacher)
        {
            Teacher = teacher;
        }

        public Teacher ToTeacher()
        {
            return Teacher;
        }
    }
}