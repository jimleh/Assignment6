using MVC_RelationalDatabase.Models;
using MVC_RelationalDatabase.Repositories;
using MVC_RelationalDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Controllers
{
    public class ClassesController : Controller
    {
        SchoolRepository repo;

        public ClassesController()
        {
            repo = new SchoolRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.GetIndexClassViewModels());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = repo.GetDetailsClassViewModel(id.Value);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID, ClassName")] Class _class)
        {
            if (ModelState.IsValid)
            {
                repo.AddClass(_class);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = repo.GetEditClassViewModel(id.Value);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Class, Selected")] EditClassViewModel vm)
        {
            if (ModelState.IsValid)
            {
                repo.EditClass(vm);
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
            var _class = repo.GetClass(id.Value);
            if (_class == null)
            {
                return HttpNotFound();
            }
            return View(_class);
        }
    }
}