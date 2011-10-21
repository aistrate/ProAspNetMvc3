using System.Diagnostics;
using System.Web.Mvc;

namespace MvcFilters.Controllers {

    public class SampleController : Controller {
        private Stopwatch timer;

        public ActionResult Index() {
            return View();
        }

        //protected override void OnActionExecuting(ActionExecutingContext filterContext) {
        //    timer = Stopwatch.StartNew();
        //}

        //protected override void OnActionExecuted(ActionExecutedContext filterContext) {
        //    timer.Stop();
        //    filterContext.HttpContext.Response.Write(
        //        string.Format("Action method elapsed time: {0}",
        //            timer.Elapsed.TotalSeconds));
        //}

        //protected override void OnResultExecuting(ResultExecutingContext filterContext) {
        //    timer = Stopwatch.StartNew();
        //}

        //protected override void OnResultExecuted(ResultExecutedContext filterContext) {
        //    timer.Stop();
        //    filterContext.HttpContext.Response.Write(
        //        string.Format("Action result elapsed time: {0}",
        //            timer.Elapsed.TotalSeconds));
        //}
    }
}
