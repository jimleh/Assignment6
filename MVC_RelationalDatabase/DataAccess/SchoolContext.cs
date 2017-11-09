using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public SchoolContext() : base("DefaultConnection") {}
    }
}