using System;
using System.Web.Mvc;

namespace Views.Controllers {
    public class HomeController : Controller {
        
        public ActionResult Index() {

            string[] fruitNames = { "Apple", "Cherry", "Pear", "Mango", "<script>do something</script>" };

            return View(fruitNames);
        }

        public ViewResult Calculate() {

            ViewBag.X = 10;
            ViewBag.Y = 20;

            return View("MyView");
        }
    }
}
