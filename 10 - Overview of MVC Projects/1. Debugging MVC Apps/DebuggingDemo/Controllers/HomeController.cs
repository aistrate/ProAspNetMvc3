using System.Web.Mvc;

namespace DebuggingDemo.Controllers {

    public class HomeController : Controller {

public ActionResult Index() {

    int firstVal = 10;
    int secondVal = 0;
    int thirdVal = 2;
    int result = firstVal / thirdVal;

    ViewData["Message"] = "Welcome to ASP.NET MVC!";

    return View(result);
}

        public ActionResult About() {
            return View();
        }
    }
}