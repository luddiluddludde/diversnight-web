﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CsvHelper;
using CsvHelper.Configuration;
using Diversnight.Web.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Diversnight.Web.Controllers
{
    public class OrgController : BaseController
    {
        // GET: Org
        public ActionResult Index()
        {
            return View(_db.Organizations.OrderBy(o => o.Name).ToList());
        }

        // GET: Org/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var organization = _db.Organizations.Find(id);
            if (organization == null)
                return HttpNotFound();

            if (CurrentUser != null && CurrentUser.Contact != null) { 
                if (organization.Contacts.All(c => c.Id != CurrentUser.Contact.Id))
                {
                    ViewBag.ShowClaimButton = true;
                }

                if (_db.Claims.Any(c => c.Organization.Id == organization.Id && c.Contact.Id == CurrentUser.Contact.Id && c.ApprovedTime == null))
                {
                    ViewBag.ShowClaimPending = true;
                }

            }
            return View(organization);
        }

        // GET: Site/Edit/5
        public ActionResult Claim(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var org = _db.Organizations.Find(id);
            if (org == null)
                return HttpNotFound();

            if (CurrentUser == null || CurrentUser.Contact == null)
                return HttpNotFound();

            _db.Claims.Add(new OrganizationClaim()
            {
                Organization = org,
                Contact = CurrentUser.Contact,
                CreatedTime = DateTime.Now
            });

            _db.SaveChanges();

            return RedirectToAction("Details", "Org", new {id = id});
        }

        public ActionResult Import()
        {
            return View();
        }
        // POST: Org/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import(HttpPostedFileBase file)
        {
            int contactsAdded = 0;

            using (var reader = new StreamReader(file.InputStream))
            using (var csvReader = new CsvReader(reader, new CsvConfiguration()
            {
                Delimiter = ";",
                HasHeaderRecord = true
            }))
            {
                var records = csvReader.GetRecords<OrgImport>().ToArray();

                foreach (var record in records)
                {
                    try
                    {
                        var org = _db.Organizations.FirstOrDefault(o => o.Name == record.Name);
                        if (org == null)
                        {
                            org = new Organization()
                            {
                                Name = record.Name,
                                Website = record.Website
                            };
                            _db.Organizations.Add(org);
                            _db.SaveChanges();
                        }
                        if (!record.Website.IsNullOrWhiteSpace())
                            org.Website = record.Website;

                        if (!string.IsNullOrWhiteSpace(org.Website) && !org.Website.StartsWith("http"))
                            org.Website = "http://" + org.Website;

                        var contact = _db.Contacts.FirstOrDefault(c => c.Email == record.ContactEmail);
                        if (contact == null)
                        {
                            var firstname = record.ContactName;
                            var lastname = record.ContactName;
                            if (record.ContactName.Contains(" "))
                            {
                                firstname = record.ContactName.Substring(0, record.ContactName.LastIndexOf(' ')).Trim();
                                lastname = record.ContactName.Substring(record.ContactName.LastIndexOf(' ')).Trim();
                            }
                            contact = new Contact()
                            {
                                Firstname = firstname,
                                Lastname = lastname,
                                Email = record.ContactEmail.Trim(),
                                Phone = record.ContactPhone.Trim(),
                            };
                            _db.Contacts.Add(contact);
                            contactsAdded++;
                            org.Contacts.Add(contact);
                        }

                        int year;
                        bool parsedYear = int.TryParse(record.SiteYear, out year);
                        if (parsedYear)
                        {
                            var site =
                                _db.Sites.FirstOrDefault(
                                    s => s.Name == record.SiteName && s.City == record.SiteCity && s.Year == year);
                            if (site == null)
                            {
                                int divers;
                                bool parsedDivers = int.TryParse(record.SiteDivers, out divers);

                                var country = _db.Countries.FirstOrDefault(c => c.Name == record.SiteCountry);
                                if (country != null)
                                {
                                    site = new Site()
                                    {
                                        Organization = org,
                                        Country = country,
                                        Name = record.SiteName,
                                        City = record.SiteCity,
                                        Year = year,
                                        Divers = parsedDivers ? divers : 0
                                    };
                                    _db.Sites.Add(site);
                                }
                                else
                                {
                                    throw new Exception(record.SiteCountry + " is not a country!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Unable to parse year");
                        }
                        _db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return Content("Could not add " + record.SiteName + " .... " + ex.Message);
                        throw new Exception(record.SiteName, ex);
                    }
                }
            }

            if (contactsAdded > 0)
            {
                ViewBag.ContactsAdded = "Added " + contactsAdded + " contacts.";
            }
            else
            {
                ViewBag.ContactsAdded = "No contacts added";
            }

            return View();
        }

        // GET: Org/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Org/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _db.Organizations.Add(organization);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: Org/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Org/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(organization).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Org/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Org/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = _db.Organizations.Find(id);
            _db.Organizations.Remove(organization);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    public class OrgImport
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string SiteName { get; set; }
        public string SiteCity { get; set; }
        public string SiteCountry { get; set; }
        public string SiteYear { get; set; }
        public string SiteDivers { get; set; }
    }
}