using MVC_RelationalDatabase.Repositories;
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
            return View(repo.GetAllClasses());
        }

        [HttpGet]
        public ActionResult Details(int? id)
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