using System;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters {
    public class MyOtherExceptionAttribute : FilterAttribute, IExceptionFilter {

        public void OnException(ExceptionContext filterContext) {

            if (filterContext.Exception is NullReferenceException) {
                filterContext.Result = new RedirectResult("/OtherSpecialErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }

    }
}