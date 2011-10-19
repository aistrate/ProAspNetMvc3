using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //public ViewResult CustomVariable()
        //{
        //    ViewBag.CustomVariable = RouteData.Values["id"];
        //    return View();
        //}

        public ViewResult CustomVariable(string id)
        {
            ViewBag.CustomVariable = id;
            return View();
        }

        //public ViewResult CustomVariable(string id = "SomeDefault")
        //{
        //    ViewBag.CustomVariable = id;
        //    return View();
        //}
    }
}
