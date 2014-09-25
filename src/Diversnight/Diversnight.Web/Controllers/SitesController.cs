using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;

namespace Diversnight.Web.Controllers
{
    public class SitesController : Controller
    {
        private DiversnightDbContext db = new DiversnightDbContext();

        // GET: Sites
        public ActionResult Index()
        {
            return View(db.Sites.OrderBy(s => s.Country.Name).ThenBy(s => s.City).ThenBy(s => s.Name).ToList());
        }

        // GET: Sites/Details/5
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

        // GET: Sites/Create
        public ActionResult Create()
        {
            ViewBag.Countries = db.Countries.ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.Code }).ToList(); ;
            ViewBag.TimeZones = db.TimeZones.ToList().Select(c => new SelectListItem { Text = c.Text, Value = c.Id.ToString() }).ToList(); ;

            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,City,Name,Description")] Site site)
        {
            if (ModelState.IsValid)
            {
                db.Sites.Add(site);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(site);
        }

        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {

            string result = new StreamReader(file.InputStream, Encoding.UTF8).ReadToEnd();
            var lines = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            foreach (var line in lines)
            {
                if (i > 0)
                {
                    var values = line.Split(';');
                    string cuntry = values[7].ToString();
                    var country =
                        db.Countries.FirstOrDefault(c => c.Name == cuntry);
                    var timezone = db.TimeZones.Find(2);
                    var site = new Site()
                    {
                        Name = values[4],
                        City = values[5],
                        Country = country,
                        TimeZone = timezone,
                        Organization = values[0],
                        Webpage = values[8],
                        Results = new List<SiteResult>()
                        {
                            new SiteResult(){Divers = 0, HasCompleted = false, Year = 2014},
                            new SiteResult(){Divers = i, HasCompleted = true, Year = 2013}
                        }
                    };
                    db.Sites.Add(site);
                    db.SaveChanges();
                }
                i++;
            }

            return RedirectToAction("Index");
        }
        // GET: Sites/Edit/5
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

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,City,Name,Description")] Site site)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        // GET: Sites/Delete/5
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

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site site = db.Sites.Find(id);
            db.Sites.Remove(site);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmptyAll()
        {
            foreach (var site in db.Sites.ToList())
            {
                foreach (var result in site.Results.ToList())
                    db.Results.Remove(result);
                db.Sites.Remove(site);
            }
            db.SaveChanges();
            return RedirectToAction("Import");
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
