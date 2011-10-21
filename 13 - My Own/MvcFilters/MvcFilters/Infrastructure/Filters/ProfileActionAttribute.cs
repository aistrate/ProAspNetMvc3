using System.Diagnostics;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch stopwatch;

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopwatch.Stop();

            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(
                    string.Format("(ProfileAction) Action method - elapsed time: {0:f4} ms<br/>",
                                  stopwatch.Elapsed.TotalSeconds * 1e3));
        }
    }
}