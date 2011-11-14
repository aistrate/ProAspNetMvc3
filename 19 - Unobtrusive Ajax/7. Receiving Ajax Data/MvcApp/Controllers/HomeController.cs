using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers {

public class HomeController : Controller {
        
    public ActionResult Index() {
        return View(new Appointment());
    }

    [HttpPost]
    public ActionResult Index(Appointment app) {
        if (Request.IsAjaxRequest()) {
            return Json(new {
                ClientName = app.ClientName,
                Date = app.Date.ToShortDateString(),
                TermsAccepted = app.TermsAccepted
            });
        } else {
            return View();
        }
    }
}


}
