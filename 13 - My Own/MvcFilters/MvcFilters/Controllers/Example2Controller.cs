using System.Web.Mvc;
using MvcFilters.Infrastructure.Filters;

namespace MvcFilters.Controllers
{
    [SimpleMessage(Message = "Controller")]
    public class Example2Controller : Controller
    {
        //[SimpleMessage(Message = "A", Order = 1)]
        //[SimpleMessage(Message = "B", Order = 2)]
        [SimpleMessage(Message = "Action")]
        public ActionResult Index()
        {
            Response.Write("Action method is running<br/>");
            return View();
        }
    }
}
