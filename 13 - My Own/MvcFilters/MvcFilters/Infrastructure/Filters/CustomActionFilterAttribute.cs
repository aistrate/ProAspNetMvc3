using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class CustomActionFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsSecureConnection)
                filterContext.Result = new HttpNotFoundResult();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // do nothing
        }
    }
}