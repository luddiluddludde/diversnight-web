using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;
using Newtonsoft.Json;

namespace Diversnight.Web.Controllers
{
    public class InstagramController : Controller
    {
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instagram
        public ActionResult Index()
        {
            return View(db.Pictures.Where(p => p.Deleted == false).OrderByDescending(p => p.CreatedTime).ToList());
        }

        // GET: Instagram/Create
        public ActionResult Import()
        {

            var start = DateTime.Now;
            int importedCount = 0;

            var tags = Config.Instagram.Tags.Split(',');
            foreach (string tag in tags)
            {
                var webClient = new WebClient();
                var list = webClient.DownloadString(
                    string.Format(Config.Instagram.ApiUrl, Config.Instagram.ClientId, tag));
                var root = JsonConvert.DeserializeObject<RootObject>(list);

                foreach (var image in root.data)
                {
                    InstagramPicture instagrampicture = null;
                    if (db.Pictures.Any())
                        instagrampicture = db.Pictures.Where(p => p.IgId == image.id).FirstOrDefault();
                    if (instagrampicture == null)
                    {
                        instagrampicture = new InstagramPicture();
                        instagrampicture.IgId = image.id;
                        instagrampicture.ImportedTime = DateTime.Now;
                        instagrampicture.CreatedTime = UnixTimeStampToDateTime(double.Parse(image.created_time));
                        instagrampicture.Caption = image.caption.text;
                        instagrampicture.ImageUrl = image.images.standard_resolution.url;
                        instagrampicture.Url = image.link;

                        db.Pictures.Add(instagrampicture);
                        importedCount++;
                    }
                }
                db.SaveChanges();
            }

            var end = DateTime.Now;

            return Content("Imported " + importedCount + " pictures in " + (end - start).Milliseconds + " ms");
        }

        // GET: Instagram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstagramPicture instagramPicture = db.Pictures.Find(id);
            if (instagramPicture == null)
            {
                return HttpNotFound();
            }
            return View(instagramPicture);
        }

        // POST: Instagram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstagramPicture instagramPicture = db.Pictures.Find(id);
            db.Pictures.Remove(instagramPicture);
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
