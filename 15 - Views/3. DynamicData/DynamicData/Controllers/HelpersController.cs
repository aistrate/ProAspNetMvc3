using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicData.Controllers {
    public class HelpersController : Controller {

        public ActionResult Index() {

          //  ViewData["DataValue"] = "View Data Data Val";
            ViewData["DataValue.Local"] = "XXX";

          //  ViewBag.DataValue = "ViewBag Data Value";

            //TempData["DataValue"] = "Temp Val";

            return View(new MyData {DataValue = "My Data Value"});
        }
    }

    public class MyData {

        public string DataValue { get; set; }
    }
}
