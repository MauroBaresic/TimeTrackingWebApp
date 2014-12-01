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
    public class PROJECTTIMETOTALsController : Controller
    {
        private TimeTrackingDBEntities2 db = new TimeTrackingDBEntities2();

        //
        // GET: /PROJECTTIMETOTALs/

        public ActionResult Index()
        {
            return View(db.PROJECTTIMETOTALs.ToList());
        }

        //
        // GET: /PROJECTTIMETOTALs/Details/5

        public ActionResult Details(int id = 0)
        {
            PROJECTTIMETOTAL projecttimetotal = db.PROJECTTIMETOTALs.Find(id);
            if (projecttimetotal == null)
            {
                return HttpNotFound();
            }
            return View(projecttimetotal);
        }

        //
        // GET: /PROJECTTIMETOTALs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PROJECTTIMETOTALs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROJECTTIMETOTAL projecttimetotal)
        {
            if (ModelState.IsValid)
            {
                db.PROJECTTIMETOTALs.Add(projecttimetotal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projecttimetotal);
        }

        //
        // GET: /PROJECTTIMETOTALs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PROJECTTIMETOTAL projecttimetotal = db.PROJECTTIMETOTALs.Find(id);
            if (projecttimetotal == null)
            {
                return HttpNotFound();
            }
            return View(projecttimetotal);
        }

        //
        // POST: /PROJECTTIMETOTALs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PROJECTTIMETOTAL projecttimetotal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecttimetotal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projecttimetotal);
        }

        //
        // GET: /PROJECTTIMETOTALs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PROJECTTIMETOTAL projecttimetotal = db.PROJECTTIMETOTALs.Find(id);
            if (projecttimetotal == null)
            {
                return HttpNotFound();
            }
            return View(projecttimetotal);
        }

        //
        // POST: /PROJECTTIMETOTALs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECTTIMETOTAL projecttimetotal = db.PROJECTTIMETOTALs.Find(id);
            db.PROJECTTIMETOTALs.Remove(projecttimetotal);
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