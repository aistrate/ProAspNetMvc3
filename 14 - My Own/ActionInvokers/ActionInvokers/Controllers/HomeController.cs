using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionInvokers.Controllers
{
    public class HomeController : Controller
    {
        [ActionName("Index")]
        public ActionResult MyAction()
        {
            return View();
        }

        [NonAction]
        public ActionResult NonAction()
        {
            return View("Index");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(string.Format("You requested the \"{0}\" action", actionName));
        }
    }
}
