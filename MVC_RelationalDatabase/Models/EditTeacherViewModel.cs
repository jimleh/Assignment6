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
        public int TeacherID { get; set; }
        [Required, DisplayName("Name:")]
        public string TeacherName { get; set; }

        public IEnumerable<Class> Classes { get; set; }
        public bool[] Selected { get; set; }

        public EditTeacherViewModel()
        {
            Classes = new List<Class>();
        }

        public Teacher ToTeacher()
        {
            return new Teacher { TeacherID = this.TeacherID, Classes = this.Classes.ToList(), TeacherName = this.TeacherName };
        }
    }
}