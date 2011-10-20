using System.Web.Mvc;

namespace ControllersAndActions.Controllers {

    public class DerivedController : Controller {
    
        public void Index() {

            string controller = (string)RouteData.Values["controller"];
            string action = (string)RouteData.Values["action"];

            Response.Write(
                string.Format("Controller: {0}, Action: {1}", controller, action));
        }

        public ActionResult Redirect() {
            return Redirect("/Derived/Index");
        }
    }
}