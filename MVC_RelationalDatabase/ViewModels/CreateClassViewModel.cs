using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class CreateClassViewModel
    {
        public int ClassID { get; set; }
        [Required, Display(Name = "Name")]
        public string ClassName { get; set; }
    }
}