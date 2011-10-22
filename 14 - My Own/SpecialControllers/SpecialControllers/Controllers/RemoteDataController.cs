using System.Web.Mvc;
using SpecialControllers.Models;

namespace SpecialControllers.Controllers
{
    public class RemoteDataController : Controller
    {
        public ActionResult Data()
        {
            return View((object)new RemoteService().GetRemoteData());
        }
    }
}
