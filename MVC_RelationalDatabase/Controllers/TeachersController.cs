using MVC_RelationalDatabase.ViewModels;
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
            return View(repo.GetIndexTeacherViewModels());
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
            var vm = repo.GetCreateTeacherViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeacherID, TeacherName")] CreateTeacherViewModel vm)
        {
            if(ModelState.IsValid)
            {
                repo.AddTeacher(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = repo.GetEditTeacherViewModel(id.Value);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Teacher, Selected")] EditTeacherViewModel vm)
        {
            if (ModelState.IsValid)
            {
                repo.EditTeacher(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = repo.GetTeacher(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var teacher = repo.GetTeacher(id);
            repo.RemoveTeacher(teacher);
            return RedirectToAction("Index");
        }
    }
}