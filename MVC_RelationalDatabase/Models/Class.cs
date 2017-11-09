using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        [Required, DisplayName("Class")]
        public string ClassName { get; set; }

        public Class()
        {
            Teachers = new List<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}