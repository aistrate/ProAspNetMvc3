using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers {
    public class HomeController : Controller {
 
        public ActionResult Index() {
            return View((object)string.Empty);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(string term) {
            return View("Search", (object) term);
        }
    }
}
