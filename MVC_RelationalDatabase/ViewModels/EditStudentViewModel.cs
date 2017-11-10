using System.Collections.Generic;
using MVC_RelationalDatabase.Models;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.ViewModels
{
    public class EditStudentViewModel
    {
        public Student Student {get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; }

        public EditStudentViewModel() {}
    }
}