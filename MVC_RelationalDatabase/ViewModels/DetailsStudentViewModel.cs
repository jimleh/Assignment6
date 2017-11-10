using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class DetailsStudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }

        public DetailsStudentViewModel()
        {
            Teachers = new List<Teacher>();
        }
    }
}