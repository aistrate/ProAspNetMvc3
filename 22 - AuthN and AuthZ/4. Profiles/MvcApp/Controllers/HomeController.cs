using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers {
    public class HomeController : Controller {


        //[Authorize(Roles="SiteAdministrator")]
public ActionResult Index() {

    ViewBag.Name = HttpContext.Profile["Name"];
    ViewBag.City = HttpContext.Profile.GetProfileGroup("Address")["City"];

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
