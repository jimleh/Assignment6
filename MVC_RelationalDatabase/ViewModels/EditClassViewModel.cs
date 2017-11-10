using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class EditClassViewModel
    {
        public Class Class { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
        public bool[] Selected { get; set; }

        public EditClassViewModel()
        {
            Teachers = new List<Teacher>();
        }
    }
}