using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;
using Newtonsoft.Json;

namespace Diversnight.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            const int countYear = 2014;

            ViewBag.SiteCount = db.Sites.Count(s => s.Year == countYear);
            ViewBag.CountryCount = db.Countries.Count(c => c.Sites.Any(s => s.Year == countYear));
            ViewBag.CountYear = countYear;

            ViewBag.Pictures = db.Pictures.Where(p => p.Deleted == false).OrderByDescending(p => p.CreatedTime).ToList();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }
    }
}