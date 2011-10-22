using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers {
    public class FirstController : Controller {
        //
        // GET: /First/

        public ActionResult Index() {
            ViewBag.Message = "Hello from the FirstController class";
            return View();
        }

    }
}
