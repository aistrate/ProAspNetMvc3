using System.Web.Mvc;

namespace CustomRouting.Controllers
{
    public class LegacyController : Controller
    {
        public ActionResult GetLegacyUrl(string legacyUrl)
        {
            return View((object)legacyUrl);
        }
    }
}
