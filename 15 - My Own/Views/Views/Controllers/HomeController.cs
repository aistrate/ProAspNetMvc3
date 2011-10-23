using System.Web.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //WebViewPage<string[]>;
            return View(new string[] { "Apple", "Orange", "Mango" });
        }

        public ViewResult Calculate()
        {
            ViewBag.X = 5;
            ViewBag.Y = 7;
            return View();
        }

        public ActionResult NoView()
        {
            return View();
        }
    }
}
