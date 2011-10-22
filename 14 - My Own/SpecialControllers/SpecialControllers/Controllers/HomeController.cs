using System.Web.Mvc;
using System.Web.SessionState;

namespace SpecialControllers.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Session["Message"] = "Hello";
            return View();
        }

        public ActionResult Index2()
        {
            return View("Index");
        }
    }
}
