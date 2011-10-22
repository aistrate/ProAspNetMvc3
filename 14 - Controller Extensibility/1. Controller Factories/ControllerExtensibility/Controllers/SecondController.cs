using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers {
    public class SecondController : Controller {
        //
        // GET: /Second/

        public ActionResult Index() {
            ViewBag.Message = "Hello from the SecondController class";
            return View();
        }

    }
}
