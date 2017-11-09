using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required, DisplayName("Name")]
        public string StudentName { get; set; }
        [DisplayName("Email")]
        public string StudentEmail { get; set; }
        [DisplayName("Phone")]
        public string StudentPhone { get; set; }
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
    }
}