using System.Diagnostics;
using System.Web.Mvc;
using MvcFilters.Infrastructure.Filters;

namespace MvcFilters.Controllers
{
    public class SampleController : Controller
    {
        [ProfileAction]
        [ProfileResult]
        public ActionResult Index()
        {
            return View();
        }

        private Stopwatch stopwatch;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopwatch = Stopwatch.StartNew();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopwatch.Stop();

            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(
                    string.Format("(SampleController) Action method - elapsed time: {0:f4} ms<br/>",
                                  stopwatch.Elapsed.TotalSeconds * 1e3));
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            stopwatch = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopwatch.Stop();

            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(
                    string.Format("(SampleController) Result execution - elapsed time: {0:f4} ms<br/>",
                                  stopwatch.Elapsed.TotalSeconds * 1e3));
        }
    }
}
