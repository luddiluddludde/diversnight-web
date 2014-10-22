using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Diversnight.Web.Controllers
{
    public class SiteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Site
        public ActionResult Index()
        {
            return View(db.Sites.ToList());
        }

        // GET: Site/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // GET: Site/Create
        [Authorize]
        public ActionResult Register()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var model = new RegisterSiteViewModel();

            if (user.Contact != null && user.Contact.Organizer != null)
            {

                var orgItems = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = user.Contact.Organizer.Name,
                        Value = user.Contact.Organizer.Id.ToString(),
                        Selected = true
                    }
                };

                var countryItems = db.Countries.ToList().Select(
                    country => new SelectListItem()
                    {
                        Text = country.Name,
                        Value = country.Id.ToString()
                    }).ToList();

                model.Organizations = orgItems;
                model.Countries = countryItems;

                var oldSite = user.Contact.Organizer.Sites.FirstOrDefault(s => s.Year == 2013);
                if (oldSite != null)
                {
                    ViewBag.ShowCopyButton = true;
                    ViewBag.CopySite = oldSite;
                }
            }

            return View(model);
        }

        // POST: Site/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Year,TimeZone,Latitude,Longitude,City,Name,Description")] Site site)
        {
            if (ModelState.IsValid)
            {
                db.Sites.Add(site);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(site);
        }

        // GET: Site/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Site/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,TimeZone,Latitude,Longitude,City,Name,Description")] Site site)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        // GET: Site/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Site/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site site = db.Sites.Find(id);
            db.Sites.Remove(site);
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
