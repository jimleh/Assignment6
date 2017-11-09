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
    public class StudentsController : Controller
    {
        SchoolRepository repo;

        public StudentsController()
        {
            repo = new SchoolRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.GetAllStudents());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = repo.GetStudent(id.Value);
            if(student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(repo.GetCreateStudentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID, StudentName, ClassID")] CreateStudentViewModel studentVM)
        {
            if(ModelState.IsValid)
            {
                repo.AddStudent(studentVM);
                return RedirectToAction("Index");
            }
            return View(studentVM);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var studentVM = repo.GetEditStudentViewModel(id.Value);
            if (studentVM == null)
            {
                return HttpNotFound();
            }

            return View(studentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student")] EditStudentViewModel studentVM)
        {
            if (ModelState.IsValid)
            {
                repo.EditStudent(studentVM);
                return RedirectToAction("Index");
            }
            return View(studentVM);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = repo.GetStudent(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Student student)
        {
            repo.RemoveStudent(student);
            return RedirectToAction("Index");
        }

    }
}