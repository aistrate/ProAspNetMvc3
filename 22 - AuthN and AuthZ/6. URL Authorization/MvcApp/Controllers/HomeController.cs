using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Configuration;

namespace MvcApp.Controllers {
    public class HomeController : Controller {



        public ActionResult Index() {

            try {
                ViewBag.Name = HttpContext.Profile["Name"];
                ViewBag.City = HttpContext.Profile.GetProfileGroup("Address")["City"];
            } catch (SettingsPropertyNotFoundException) {
                // do nothing
            }

            return View();
        }

        [HttpPost]
        public ViewResult Index(string name, string city) {

            HttpContext.Profile["Name"] = name;
            HttpContext.Profile.GetProfileGroup("Address")["City"] = city;

            return View();
        }

    }
}
