using System.Collections.Generic;
using MVC_RelationalDatabase.Models;

namespace MVC_RelationalDatabase.ViewModels
{
    public class EditTeacherViewModel
    {
        public Teacher Teacher { get; set; }

        public IEnumerable<Class> Classes { get; set; }
        public bool[] Selected { get; set; }

        public EditTeacherViewModel() {}
    }
}