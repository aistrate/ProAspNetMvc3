using System.Diagnostics;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class ProfileAllAttribute : ActionFilterAttribute
    {
        private Stopwatch stopwatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopwatch.Stop();

            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(
                    string.Format("(ProfileAll) Action method - elapsed time: {0:f4} ms<br/>",
                                  stopwatch.Elapsed.TotalSeconds * 1e3));
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopwatch.Stop();

            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(
                    string.Format("(ProfileAll) Result execution - elapsed time: {0:f4} ms<br/>",
                                  stopwatch.Elapsed.TotalSeconds * 1e3));
        }
    }
}