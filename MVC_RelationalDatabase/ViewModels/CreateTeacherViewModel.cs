using MVC_RelationalDatabase.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_RelationalDatabase.ViewModels
{
    public class CreateTeacherViewModel
    {
        public int TeacherID { get; set; }
        [Required, Display(Name = "Name:")]
        public string TeacherName { get; set; }

        public Teacher ToTeacher()
        {
            return new Teacher
            {
                TeacherID = this.TeacherID,
                Classes = new List<Class>(),
                TeacherName = this.TeacherName
            };
        }
    }
}