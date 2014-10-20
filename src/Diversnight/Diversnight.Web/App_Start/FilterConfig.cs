using System;
using System.Web;
using System.Web.Mvc;

namespace Diversnight.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var viewResult = new ViewResult();

                viewResult.ViewName = "~/Views/Errors/_Unauthorized.cshtml";
                viewResult.ViewBag.Url = filterContext.RequestContext.HttpContext.Request.Url;
                viewResult.ViewBag.Roles = Roles;

                filterContext.Result = viewResult;
                filterContext.RequestContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
