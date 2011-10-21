using System.Web.Mvc;
using System;

namespace MvcFilters.Infrastructure.Filters {

    public class MyExceptionAttribute: FilterAttribute, IExceptionFilter {

        public void OnException(ExceptionContext filterContext) {

            if (!filterContext.ExceptionHandled && 
                filterContext.Exception is NullReferenceException) {

                filterContext.Result = new RedirectResult("/SpecialErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}