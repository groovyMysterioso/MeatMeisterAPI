using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatMeisterAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return Redirect("home.htm");
        }
        [HttpPost]
        public ActionResult Index(string value)
        {
            ViewBag.Title = "Success!";

            return View();
        }
    }
}
