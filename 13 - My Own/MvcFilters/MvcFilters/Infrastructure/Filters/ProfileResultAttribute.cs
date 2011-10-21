using System.Diagnostics;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch stopwatch;

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopwatch.Stop();

            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(
                    string.Format("(ProfileResult) Result execution - elapsed time: {0:f4} ms<br/>",
                                  stopwatch.Elapsed.TotalSeconds * 1e3));
        }
    }
}