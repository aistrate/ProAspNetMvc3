using System.Web.Mvc;
using MvcFilters.Models.Abstract;
using Ninject;

namespace MvcFilters.Infrastructure.Filters {
    public class DIMessageAttribute : FilterAttribute, IActionFilter {

        [Inject]
        public IMessageProvider Provider { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext) {
            filterContext.HttpContext.Response.Write(
                string.Format("[Before Action: {0}]", Provider.Message));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            filterContext.HttpContext.Response.Write(
                string.Format("[After Action: {0}]", Provider.Message));
        }
    }
}