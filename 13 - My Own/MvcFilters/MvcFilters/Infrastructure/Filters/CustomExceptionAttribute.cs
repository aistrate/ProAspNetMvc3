using System;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class CustomExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled &&
                filterContext.Exception is NullReferenceException)
            {
                //filterContext.Result = new RedirectResult("/Content/SpecialErrorPage.htm");

                filterContext.Result = new ViewResult
                {
                    ViewName = "SpecialError",
                    ViewData = new ViewDataDictionary
                    {
                        Model = new HandleErrorInfo(
                            filterContext.Exception,
                            (string)filterContext.RouteData.Values["controller"],
                            (string)filterContext.RouteData.Values["action"])
                    },
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }
}