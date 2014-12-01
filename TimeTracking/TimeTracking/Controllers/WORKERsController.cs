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
    public class WORKERsController : Controller
    {
        private TimeTrackingDBEntities2 db = new TimeTrackingDBEntities2();

        //
        // GET: /WORKERs/

        public ActionResult Index()
        {
            return View(db.WORKERs.ToList());
        }

        //
        // GET: /WORKERs/Details/5

        public ActionResult Details(int id = 0)
        {
            WORKER worker = db.WORKERs.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        //
        // GET: /WORKERs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WORKERs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WORKER worker)
        {
            if (ModelState.IsValid)
            {
                db.WORKERs.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        //
        // GET: /WORKERs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WORKER worker = db.WORKERs.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        //
        // POST: /WORKERs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WORKER worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        //
        // GET: /WORKERs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WORKER worker = db.WORKERs.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        //
        // POST: /WORKERs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WORKER worker = db.WORKERs.Find(id);
            db.WORKERs.Remove(worker);
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