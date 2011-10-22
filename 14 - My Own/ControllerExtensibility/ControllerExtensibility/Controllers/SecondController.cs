using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
    public class SecondController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ControllerName = "Second";
            ViewBag.RouteValueController = RouteData.Values["controller"];
            return View();
        }
    }
}
