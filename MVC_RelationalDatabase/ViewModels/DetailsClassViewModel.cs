using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.ViewModels
{
    public class DetailsClassViewModel
    {
        public Class Class { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}