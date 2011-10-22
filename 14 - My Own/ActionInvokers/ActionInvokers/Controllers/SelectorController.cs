using System.Web.Mvc;
using ActionInvokers.Infrastructure;

namespace ActionInvokers.Controllers
{
    public class SelectorController : Controller
    {
        [ActionName("Index")]
        public ActionResult FirstMethod()
        {
            ViewBag.Message = "Message from FirstMethod";
            return View();
        }

        [Local]
        [ActionName("Index")]
        public ActionResult SecondMethod()
        {
            ViewBag.Message = "Message from SecondMethod";
            return View();
        }
    }
}
