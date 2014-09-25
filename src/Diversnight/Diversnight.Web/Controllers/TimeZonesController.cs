using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;
using TimeZone = Diversnight.Web.Models.TimeZone;

namespace Diversnight.Web.Controllers
{
    public class TimeZonesController : Controller
    {
        private DiversnightDbContext db = new DiversnightDbContext();

        // GET: TimeZones
        public ActionResult Index()
        {
            return View(db.TimeZones.OrderBy(p => p.Abbreviation).ToList());
        }

        // GET: TimeZones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeZone timeZone = db.TimeZones.Find(id);
            if (timeZone == null)
            {
                return HttpNotFound();
            }
            return View(timeZone);
        }

        // GET: TimeZones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeZones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Offset,UseDST,Name,Abbreviation,Text")] TimeZone timeZone)
        {
            if (ModelState.IsValid)
            {
                db.TimeZones.Add(timeZone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeZone);
        }

        // GET: TimeZones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeZone timeZone = db.TimeZones.Find(id);
            if (timeZone == null)
            {
                return HttpNotFound();
            }
            return View(timeZone);
        }

        // POST: TimeZones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Offset,UseDST,Name,Abbreviation,Text")] TimeZone timeZone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeZone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeZone);
        }

        // GET: TimeZones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeZone timeZone = db.TimeZones.Find(id);
            if (timeZone == null)
            {
                return HttpNotFound();
            }
            return View(timeZone);
        }

        // POST: TimeZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeZone timeZone = db.TimeZones.Find(id);
            db.TimeZones.Remove(timeZone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
