using MVC_RelationalDatabase.Models;
using MVC_RelationalDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Controllers
{
    public class TeachersController : Controller
    {
        SchoolRepository repo;

        public TeachersController()
        {
            repo = new SchoolRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.GetAllTeachers());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = repo.GetTeacher(id.Value);
            if(teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var teacherVM = repo.GetCreateTeacherViewModel();
            return View(teacherVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeacherID, TeacherName")] CreateTeacherViewModel teacherVM)
        {
            if(ModelState.IsValid)
            {
                repo.AddTeacher(teacherVM);
                return RedirectToAction("Index");
            }
            return View(teacherVM);
        }
    }
}