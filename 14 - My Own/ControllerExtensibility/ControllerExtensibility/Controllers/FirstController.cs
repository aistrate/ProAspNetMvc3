using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
    public class FirstController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ControllerName = "First";
            ViewBag.RouteValueController = RouteData.Values["controller"];
            return View();
        }
    }
}
