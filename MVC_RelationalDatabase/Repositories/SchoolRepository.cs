using MVC_RelationalDatabase.DataAccess;
using MVC_RelationalDatabase.Models;
using MVC_RelationalDatabase.ViewModels;
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

        // Student ViewModels
        public CreateStudentViewModel GetCreateStudentViewModel()
        {
            var vm = new CreateStudentViewModel
            {
                Classes = new SelectList(GetAllClasses(), "ClassID", "ClassName")
            };

            return vm;
        }
        public DetailsStudentViewModel GetDetailsStudentViewModel(int id)
        {
            var student = GetStudent(id);

            if (student == null)
            {
                return null;
            }

            var teachers = GetAllTeachers().Where(t => t.Classes.Any(c => c.ClassID == student.ClassID));

            var vm = new DetailsStudentViewModel
            {
                Student = student,
                Teachers = teachers
            };

            return vm;
        }
        public EditStudentViewModel GetEditStudentViewModel(int id)
        {
            var student = GetStudent(id);
            if(student == null)
            {
                return null;
            }

            var vm = new EditStudentViewModel
            {
                Student = student,
                Classes = new SelectList(GetAllClasses(), "ClassID", "ClassName")
            };

            return vm;
        }
        public IEnumerable<IndexStudentViewModel> GetIndexStudentViewModels()
        {
            var models = new List<IndexStudentViewModel>();
            foreach(var s in GetAllStudents())
            {
                var vm = new IndexStudentViewModel
                {
                    StudentID = s.StudentID,
                    StudentName = s.StudentName,
                    ClassName = GetAllClasses().FirstOrDefault(c => c.ClassID == s.ClassID).ClassName,
                    NumberOfTeachers = 0
                };
                foreach (var t in GetAllTeachers())
                {
                    vm.NumberOfTeachers += t.Classes.Where(c => c.ClassID == s.ClassID).Count();
                }
                
                models.Add(vm);
            }
            return models;
        }

        // Teacher ViewModels
        public CreateTeacherViewModel GetCreateTeacherViewModel()
        {
            var vm = new CreateTeacherViewModel();
            return vm;
        }
        public DetailsTeacherViewModel GetDetailsTeacherViewModel(int id)
        {
            var teacher = GetTeacher(id);

            if (teacher == null)
            {
                return null;
            }

            var students = GetAllStudents().Where(s => teacher.Classes.Any(c => c.ClassID == s.ClassID));

            var vm = new DetailsTeacherViewModel
            {
                Teacher = teacher,
                Students = students
            };

            return vm;
        }
        public EditTeacherViewModel GetEditTeacherViewModel(int id)
        {
            var teacher = GetTeacher(id);

            if (teacher == null)
            {
                return null;
            }

            var vm = new EditTeacherViewModel
            {
                Teacher = teacher
            };

            return vm;
        }
        public IEnumerable<IndexTeacherViewModel> GetIndexTeacherViewModels()
        {
            var models = new List<IndexTeacherViewModel>();
            foreach (var t in GetAllTeachers())
            {
                var vm = new IndexTeacherViewModel
                {
                        TeacherID = t.TeacherID,
                        TeacherName = t.TeacherName,
                        NumberOfClasses = t.Classes.Count,
                        NumberOfStudents = 0
                };
                vm.NumberOfStudents += GetAllStudents().Where(s => t.Classes.Any(c => c.ClassID == s.ClassID)).Count();
                models.Add(vm);
            }
            return models;
        }

        // Class ViewModels
        public DetailsClassViewModel GetDetailsClassViewModel(int id)
        {
            var _class = GetClass(id);
            if (_class == null)
            {
                return null;
            }

            var vm = new DetailsClassViewModel
            {
                Class = _class,
                Students = GetAllStudents().Where(s => s.ClassID == id)
            };

            return vm;
        }
        public EditClassViewModel GetEditClassViewModel(int id)
        {
            var _class = GetClass(id);
            if(_class == null)
            {
                return null;
            }

            var teachers = GetAllTeachers();

            var vm = new EditClassViewModel
            {
                Class = _class,
                Teachers = teachers,
                Selected = new bool[teachers.Count()]
            };

            for (int i = 0; i < vm.Teachers.Count(); i++)
            {
                if (vm.Class.Teachers.Contains(vm.Teachers.ElementAt(i)))
                {
                    vm.Selected[i] = true;
                }
            }

            return vm;
        }
        public IEnumerable<IndexClassViewModel> GetIndexClassViewModels()
        {
            var models = new List<IndexClassViewModel>();
            foreach(var c in GetAllClasses())
            {
                models.Add(
                    new IndexClassViewModel 
                    { 
                        ClassID = c.ClassID,
                        ClassName = c.ClassName,
                        NumberOfStudents = GetAllStudents().Where(s => s.ClassID == c.ClassID).Count(),
                        NumberOfTeachers = c.Teachers.Count
                    }
                );
            }
            return models;
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
            var student = studentVM.Student;
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
        public void EditClass(EditClassViewModel vm)
        {
            var teachers = GetAllTeachers();
            var _class = GetClass(vm.Class.ClassID);
            _class.Teachers = new List<Teacher>();
            for (int i = 0; i < teachers.Count(); i++)
            {
                if (vm.Selected[i])
                {
                    _class.Teachers.Add(teachers.ElementAt(i));
                }
                else
                {
                    var teacher = teachers.ElementAt(i);
                    if (teacher.Classes.Contains(_class))
                    {
                        teacher.Classes.Remove(_class);
                        context.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
                    }
                }
            }
            _class.ClassName = vm.Class.ClassName;

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
            var teacher = vm.Teacher;
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