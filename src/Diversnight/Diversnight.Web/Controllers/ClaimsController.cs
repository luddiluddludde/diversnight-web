using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diversnight.Web.Models;
using Microsoft.AspNet.Identity;

namespace Diversnight.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class ClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Claims
        public ActionResult Index()
        {
            return View(db.Claims.Where(c => c.ApprovedTime == null).ToList());
        }

        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var claim = db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int id)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = db.Users.FirstOrDefault(u => u.Id == userId);
            if (currentUser != null && currentUser.Contact != null)
            {

                var claim = db.Claims.Find(id);
                if (claim == null)
                {
                    return HttpNotFound();
                }
                if (claim.Organization.Contacts.All(c => c.Id != claim.Contact.Id))
                {
                        claim.Organization.Contacts.Add(claim.Contact);
                        claim.ApprovedBy = currentUser.Contact;
                        claim.ApprovedTime = DateTime.Now;
                        db.SaveChanges();

                        if (!EmailHelper.Instance.SendMail(claim.Contact.Email, "Organization claim approved",
                            String.Format("<p>Your request to be a contact for {0} has been approved by {1}.</p><p>Regards,<br />Diversnight</p>", claim.Organization.Name, currentUser.Contact.Name)))
                        {
                            return Content("Email not sent? Check Mandrill..");
                        }

                }
            }
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
