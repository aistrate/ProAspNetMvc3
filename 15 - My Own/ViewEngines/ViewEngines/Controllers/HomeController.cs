using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewEngines.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Hello, world";
            ViewData["Time"] = DateTime.Now.ToLongTimeString();

            return View("DebugData");
        }
    }
}
