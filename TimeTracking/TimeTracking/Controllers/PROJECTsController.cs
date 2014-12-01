using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Models;

namespace TimeTracking.Controllers
{
    public class PROJECTsController : Controller
    {
        private TimeTrackingDBEntities2 db = new TimeTrackingDBEntities2();

        //
        // GET: /PROJECTs/

        public ActionResult Index()
        {
            return View(db.PROJECTs.ToList());
        }

        //
        // GET: /PROJECTs/Details/5

        public ActionResult Details(int id = 0)
        {
            PROJECT project = db.PROJECTs.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /PROJECTs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PROJECTs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROJECT project)
        {
            if (ModelState.IsValid)
            {
                db.PROJECTs.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        //
        // GET: /PROJECTs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PROJECT project = db.PROJECTs.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /PROJECTs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PROJECT project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /PROJECTs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PROJECT project = db.PROJECTs.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /PROJECTs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECT project = db.PROJECTs.Find(id);
            db.PROJECTs.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}