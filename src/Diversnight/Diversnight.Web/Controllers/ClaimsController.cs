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
    public class ClaimsController : BaseController
    {
        public ActionResult Index()
        {
            return View(_db.Claims.Where(c => c.ApprovedTime == null).ToList());
        }

        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var claim = _db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int id)
        {
            if (CurrentUser != null && CurrentUser.Contact != null)
            {
                var claim = _db.Claims.Find(id);
                if (claim == null)
                {
                    return HttpNotFound();
                }
                if (claim.Organization.Contacts.All(c => c.Id != claim.Contact.Id))
                {
                    claim.Organization.Contacts.Add(claim.Contact);
                    claim.ApprovedBy = CurrentUser.Contact;
                    claim.ApprovedTime = DateTime.Now;
                    _db.SaveChanges();

                    if (!EmailHelper.Instance.SendMail(claim.Contact.Email, "Organization claim approved",
                        String.Format(
                            "<p>Your request to be a contact for {0} has been approved by {1}.</p><p>Regards,<br />Diversnight</p>",
                            claim.Organization.Name, CurrentUser.Contact.Name)))
                    {
                        return Content("Email not sent? Check Mandrill..");
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
