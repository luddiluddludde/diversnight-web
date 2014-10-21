using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;

namespace Diversnight.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class ClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Claims
        public ActionResult Index()
        {
            return View(db.Claims.ToList());
        }

        // GET: Claims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationClaim organizationClaim = db.Claims.Find(id);
            if (organizationClaim == null)
            {
                return HttpNotFound();
            }
            return View(organizationClaim);
        }

        // GET: Claims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedTime,ApprovedTime")] OrganizationClaim organizationClaim)
        {
            if (ModelState.IsValid)
            {
                db.Claims.Add(organizationClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizationClaim);
        }

        // GET: Claims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationClaim organizationClaim = db.Claims.Find(id);
            if (organizationClaim == null)
            {
                return HttpNotFound();
            }
            return View(organizationClaim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedTime,ApprovedTime")] OrganizationClaim organizationClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizationClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizationClaim);
        }

        // GET: Claims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationClaim organizationClaim = db.Claims.Find(id);
            if (organizationClaim == null)
            {
                return HttpNotFound();
            }
            return View(organizationClaim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizationClaim organizationClaim = db.Claims.Find(id);
            db.Claims.Remove(organizationClaim);
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
