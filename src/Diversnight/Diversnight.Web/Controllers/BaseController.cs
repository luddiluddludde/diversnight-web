using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Diversnight.Web.Models;

namespace Diversnight.Web.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationUser _currentUser;
        public ApplicationUser CurrentUser
        {
            get
            {
                if (_currentUser != null) return _currentUser;

                if (!User.Identity.IsAuthenticated)
                    return null;
                
                var id = User.Identity.GetUserId();
                _currentUser = _db.Users.Find(id);
                
                return _currentUser;
            }
        }

        public ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}