using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers {
    public class HomeController : Controller {


        [Authorize(Roles = "SiteAdministrator")]
        public ActionResult Index() {
            return View();
        }

    }
}
