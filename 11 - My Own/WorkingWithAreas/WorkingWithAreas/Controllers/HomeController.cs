using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithAreas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();

            //ViewResult viewResult = new ViewResult();
            //viewResult.ViewBag.Message = ViewBag.Message;
            //return viewResult;
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
