using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFilters.Controllers
{
    public class Example3Controller : Controller
    {
        public ActionResult Index()
        {
            Response.Write("Main action method is running: " + DateTime.Now);
            return View();
        }

        [OutputCache(Duration=30)]
        public ActionResult ChildAction()
        {
            Response.Write("Child action method is running: " + DateTime.Now);
            return View();
        }
    }
}
