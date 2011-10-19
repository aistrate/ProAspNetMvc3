using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AdditionalControllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            ViewBag.Message = "This is the additional HomeController class";

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
