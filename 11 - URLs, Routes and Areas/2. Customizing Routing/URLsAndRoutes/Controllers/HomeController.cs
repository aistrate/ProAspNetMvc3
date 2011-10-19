using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URLsAndRoutes.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About() {
            return View();
        }

        public ViewResult CustomVariable(string id, string catchall) {

            ViewBag.CustomVariable = id;
            ViewBag.CatchAll = catchall;
            return View();
        }
    }
}
