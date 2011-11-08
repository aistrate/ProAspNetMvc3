using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorSections.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult PartialViews()
        {
            return View();
        }

        public ActionResult PartialViews2()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Time()
        {
            return PartialView(DateTime.Now);
        }

        [ChildActionOnly]
        public ActionResult SpecificTime(DateTime time)
        {
            return PartialView("Time", time);
        }

        public ActionResult ChildActionDemo()
        {
            return View();
        }
    }
}
