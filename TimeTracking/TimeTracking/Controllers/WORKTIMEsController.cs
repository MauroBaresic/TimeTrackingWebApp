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
    public class WORKTIMEsController : Controller
    {
        private TimeTrackingDBEntities2 db = new TimeTrackingDBEntities2();

        //
        // GET: /WORKTIMEs/

        public ActionResult Index()
        {
            var worktimes = db.WORKTIMEs.Include(w => w.PROJECT).Include(w => w.WORKER);
            return View(worktimes.ToList());
        }

        //
        // GET: /WORKTIMEs/Details/5

        public ActionResult Details(int projectId, int workerId)
        {
            WORKTIME worktime = db.WORKTIMEs.Find(projectId, workerId);
            if (worktime == null)
            {
                return HttpNotFound();
            }
            return View(worktime);
        }

        //
        // GET: /WORKTIMEs/Create

        public ActionResult Create()
        {
            ViewBag.projectId = new SelectList(db.PROJECTs, "Id", "Name");
            ViewBag.workerId = new SelectList(db.WORKERs, "Id", "Id");
            return View();
        }

        //
        // POST: /WORKTIMEs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WORKTIME worktime)
        {
            if (ModelState.IsValid)
            {
                WORKTIME w = db.WORKTIMEs.Find(worktime.projectId, worktime.workerId);
                if (w == null)
                {
                    db.WORKTIMEs.Add(worktime);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            
            ViewBag.projectId = new SelectList(db.PROJECTs, "Id", "Name", worktime.projectId);
            ViewBag.workerId = new SelectList(db.WORKERs, "Id", "firstName", worktime.workerId);
            return View(worktime);
        }

        //
        // GET: /WORKTIMEs/Edit/5

        public ActionResult Edit(int projectId , int workerId)
        {
            WORKTIME worktime = db.WORKTIMEs.Find(projectId, workerId);
            if (worktime == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectId = new SelectList(db.PROJECTs, "Id", "Name", worktime.projectId);
            ViewBag.workerId = new SelectList(db.WORKERs, "Id", "firstName", worktime.workerId);
            return View(worktime);
        }

        //
        // POST: /WORKTIMEs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WORKTIME worktime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worktime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectId = new SelectList(db.PROJECTs, "Id", "Name", worktime.projectId);
            ViewBag.workerId = new SelectList(db.WORKERs, "Id", "firstName", worktime.workerId);
            return View(worktime);
        }

        //
        // GET: /WORKTIMEs/Delete/5

        public ActionResult Delete(int projectId, int workerId)
        {
            WORKTIME worktime = db.WORKTIMEs.Find(projectId, workerId);
            if (worktime == null)
            {
                return HttpNotFound();
            }
            return View(worktime);
        }

        //
        // POST: /WORKTIMEs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int projectId, int workerId)
        {
            WORKTIME worktime = db.WORKTIMEs.Find(projectId, workerId);
            db.WORKTIMEs.Remove(worktime);
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