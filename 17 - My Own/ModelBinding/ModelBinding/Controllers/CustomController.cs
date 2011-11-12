using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Controllers
{
    public class CustomController : Controller
    {
        public ActionResult Clock(DateTime currentTime)
        {
            return Content("The time is " + currentTime.ToLongTimeString());
        }
    }
}
