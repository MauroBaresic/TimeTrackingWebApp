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
    public class WORKERTIMETOTALsController : Controller
    {
        private TimeTrackingDBEntities2 db = new TimeTrackingDBEntities2();

        //
        // GET: /WORKERTIMETOTALs/

        public ActionResult Index()
        {
            return View(db.WORKERTIMETOTALs.ToList());
        }

        //
        // GET: /WORKERTIMETOTALs/Details/5

        public ActionResult Details(int id = 0)
        {
            WORKERTIMETOTAL workertimetotal = db.WORKERTIMETOTALs.Find(id);
            if (workertimetotal == null)
            {
                return HttpNotFound();
            }
            return View(workertimetotal);
        }

        //
        // GET: /WORKERTIMETOTALs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WORKERTIMETOTALs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WORKERTIMETOTAL workertimetotal)
        {
            if (ModelState.IsValid)
            {
                db.WORKERTIMETOTALs.Add(workertimetotal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workertimetotal);
        }

        //
        // GET: /WORKERTIMETOTALs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WORKERTIMETOTAL workertimetotal = db.WORKERTIMETOTALs.Find(id);
            if (workertimetotal == null)
            {
                return HttpNotFound();
            }
            return View(workertimetotal);
        }

        //
        // POST: /WORKERTIMETOTALs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WORKERTIMETOTAL workertimetotal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workertimetotal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workertimetotal);
        }

        //
        // GET: /WORKERTIMETOTALs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WORKERTIMETOTAL workertimetotal = db.WORKERTIMETOTALs.Find(id);
            if (workertimetotal == null)
            {
                return HttpNotFound();
            }
            return View(workertimetotal);
        }

        //
        // POST: /WORKERTIMETOTALs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WORKERTIMETOTAL workertimetotal = db.WORKERTIMETOTALs.Find(id);
            db.WORKERTIMETOTALs.Remove(workertimetotal);
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