using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class DetailsTeacherViewModel
    {
        public Teacher Teacher { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public DetailsTeacherViewModel()
        {
            Students = new List<Student>();
        }
    }
}