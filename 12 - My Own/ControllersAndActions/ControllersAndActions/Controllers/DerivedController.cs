using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");

            //return new ViewResult { ViewName = "MyView" };
            //return new ViewResult();
            //return View("MyView", "_Layout");
            //return View("~/Views/Derived/MyView.cshtml");
            //return View("~/Views/Shared/Error.cshtml");
            //return View("~/Views/Basic/Index.cshtml");
        }

        public ActionResult Redirect()
        {
            return new RedirectResult("/Derived/Index");
        }
    }
}
