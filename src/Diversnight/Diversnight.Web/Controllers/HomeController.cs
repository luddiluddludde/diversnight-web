using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;

namespace Diversnight.Web.Controllers
{
    public class HomeController : Controller
    {
        private DiversnightDbContext db = new DiversnightDbContext();

        public ActionResult Index()
        {
            //ViewBag.Divers2011 = db.Results.Where(r => r.Year == 2011).Sum(r => r.Divers);
            //ViewBag.Divers2012 = db.Results.Where(r => r.Year == 2012).Sum(r => r.Divers);
            ViewBag.Divers2013 = db.Results.Where(r => r.Year == 2013).Sum(r => r.Divers);
            var sites = db.Sites.Where(p => p.Results.Any(r => r.Year == 2014)).ToList();
            ViewBag.Sites = sites;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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