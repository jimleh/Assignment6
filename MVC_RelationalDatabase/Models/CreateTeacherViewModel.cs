using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class CreateTeacherViewModel
    {
        public int TeacherID { get; set; }
        [Required, DisplayName("Name:")]
        public string TeacherName { get; set; }

        public CreateTeacherViewModel()
        {

        }

        public Teacher ToTeacher()
        {
            return new Teacher { TeacherID = this.TeacherID, Classes = new List<Class>(), TeacherName = this.TeacherName };
        }
    }
}