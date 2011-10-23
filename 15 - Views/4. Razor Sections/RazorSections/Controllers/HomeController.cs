using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorSections.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult PartialDemo() {
            return View();
        }

        public ActionResult ChildActionDemo() {
            return View();                
        }

        [ChildActionOnly]
        public ActionResult Time(DateTime time) {
            return View(time);
        }

    }
}
