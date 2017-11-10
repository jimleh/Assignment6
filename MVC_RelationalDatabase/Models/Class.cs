using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_RelationalDatabase.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        [Required, Display(Name = "Class Name:")]
        public string ClassName { get; set; }

        public Class()
        {
            Teachers = new List<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}