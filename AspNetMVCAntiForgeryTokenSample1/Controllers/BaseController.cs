using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspNetMVCAntiForgeryTokenSample1.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //enforce anti-forgery stuff for HttpVerbs.Post
            if (String.Compare(filterContext.HttpContext.Request.HttpMethod, "post", true) == 0)
            {
                // Normal Auth stuff
                //new AuthorizeAttribute().OnAuthorization(filterContext);
                //if (filterContext.Result != null) // Short circuit validation
                //    return;

                // Antigorgery check in data tag
                //new ValidateAntiForgeryTokenAttribute().OnAuthorization(filterContext);

                // Antigorgery check in cookie: https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/preventing-cross-site-request-forgery-csrf-attacks
                string cookieToken = "";
                string formToken = "";

                IEnumerable<string> tokenHeaders;
                //if (filterContext.HttpContext.Request.Headers.TryGetValues("RequestVerificationToken", out tokenHeaders))
                if (filterContext.HttpContext.Request.Headers["RequestVerificationToken"] != null)
                {
                    tokenHeaders = filterContext.HttpContext.Request.Headers.GetValues("RequestVerificationToken");

                    string[] tokens = tokenHeaders.First().Split(':');
                    if (tokens.Length == 2)
                    {
                        cookieToken = tokens[0].Trim();
                        formToken = tokens[1].Trim();
                    }
                }

                AntiForgery.Validate(cookieToken, formToken);
            }
            base.OnAuthorization(filterContext);
        }
    }
}