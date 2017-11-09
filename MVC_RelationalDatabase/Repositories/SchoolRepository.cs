using MVC_RelationalDatabase.DataAccess;
using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Repositories
{
    public class SchoolRepository
    {
        SchoolContext context;

        public SchoolRepository()
        {
            context = new SchoolContext();
        }

        protected void Save()
        {
            context.SaveChanges();
        }

        // GetAll- methods
        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }
        public IEnumerable<Class> GetAllClasses()
        {
            return context.Classes.ToList();
        }
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return context.Teachers.ToList();
        }

        // Get- methods
        public Student GetStudent(int id)
        {
            return context.Students.FirstOrDefault(s => s.StudentID == id);
        }
        public Class GetClass(int id)
        {
            return context.Classes.FirstOrDefault(c => c.ClassID == id);
        }
        public Teacher GetTeacher(int id)
        {
            return context.Teachers.FirstOrDefault(t => t.TeacherID == id);
        }
        public CreateStudentViewModel GetCreateStudentViewModel()
        {
            var vm = new CreateStudentViewModel();
            vm.Classes = new SelectList(GetAllClasses(), "ClassID", "ClassName");
            return vm;
        }
        public CreateStudentViewModel GetCreateStudentViewModel(int id) // Overlaoded version
        {
            var student = GetStudent(id);
            if (student == null)
            {
                return null;
            }
            var vm = new CreateStudentViewModel(student);
            vm.Classes = new SelectList(GetAllClasses(), "ClassID", "ClassName");
            return vm;
        }
        public EditStudentViewModel GetEditStudentViewModel(int id)
        {
            var student = GetStudent(id);
            if(student == null)
            {
                return null;
            }
            var vm = new EditStudentViewModel(student);
            vm.Classes = new SelectList(GetAllClasses(), "ClassID", "ClassName");
            return vm;
        }
        public CreateTeacherViewModel GetCreateTeacherViewModel()
        {
            var vm = new CreateTeacherViewModel();
            return vm;
        }
        public EditTeacherViewModel GetEditTeacherViewModel(int id)
        {
            var teacher = GetTeacher(id);
            if (teacher == null)
            {
                return null;
            }
            var vm = new EditTeacherViewModel(teacher);
            return vm;
        }

        // Add, Edit, and Delete Student methods
        public void AddStudent(CreateStudentViewModel studentVM)
        {
            var student = studentVM.ToStudent();
            context.Students.Add(student);
            Save();
        }
        public void EditStudent(EditStudentViewModel studentVM)
        {
            var student = studentVM.ToStudent();
            context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public void RemoveStudent(Student student)
        {
            context.Students.Remove(student);
            Save();
        }


        // Add, Edit, and Delete Class methods
        public void AddClass(Class _class)
        {
            context.Classes.Add(_class);
            Save();
        }
        public void EditClass(Class _class)
        {
            context.Entry(_class).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public void RemoveClass(Class _class)
        {
            context.Classes.Remove(_class);
            Save();
        }

        // Add, Edit, and Delete Teacher methods
        public void AddTeacher(CreateTeacherViewModel vm)
        {
            var teacher = vm.ToTeacher();
            context.Teachers.Add(teacher);
            Save();
        }
        public void EditTeacher(EditTeacherViewModel vm)
        {
            var all = GetAllClasses();
            vm.Selected = new bool[all.Count()];
            var tmp = new List<Class>();
            for(int i = 0; i < all.Count(); i++)
            {
                if(vm.Selected[i])
                {
                    tmp.Add(all.ElementAt(i));
                }
            }
            var teacher = vm.ToTeacher();

            context.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public void RemoveTeacher(Teacher teacher)
        {
            context.Teachers.Remove(teacher);
            Save();
        }


    }
}