namespace MVC_RelationalDatabase.Migrations
{
    using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_RelationalDatabase.DataAccess.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_RelationalDatabase.DataAccess.SchoolContext context)
        {
            var teacher = new Teacher { TeacherID = 1, TeacherName = "Lärare1" };
            var _class1 = new Class { ClassID = 1, ClassName = "7A", Teachers = new List<Teacher>() };
            var _class2 = new Class { ClassID = 2, ClassName = "7B", Teachers = new List<Teacher>() };
            _class1.Teachers.Add(teacher);
            _class2.Teachers.Add(teacher);
            context.Classes.AddOrUpdate(c => c.ClassID, _class1, _class2);
        }
    }
}
