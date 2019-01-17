using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCAntiForgeryTokenSample1.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View("TransferAmt");
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

        
        public ActionResult TransferAmt()
        {
            // Money transfer logic goes here  
            return Content(Request.Form["amount"] + " has been transferred to account " + Request.Form["account"]);
        }

        public ActionResult AjaxCall(PostObj val)
        {
            // Money transfer logic goes here  
            return Content(" Value is " + val.Name);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PostCall(PostObj val)
        {
            // Money transfer logic goes here  
            return Content(" Value is " + val.Name);
        }

        //[HttpGet]
        public ActionResult GetCall()
        {
            // Money transfer logic goes here  
            return Content("get done");
        }
    }

    public class PostObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}