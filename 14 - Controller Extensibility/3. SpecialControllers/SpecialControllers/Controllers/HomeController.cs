using System.Web.Mvc;
using System.Web.SessionState;

namespace SpecialControllers.Controllers {

    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : Controller {
  
        public ActionResult Index() {

            ViewData["Message"] = "Hello";

            return View();
        }

    }
}
