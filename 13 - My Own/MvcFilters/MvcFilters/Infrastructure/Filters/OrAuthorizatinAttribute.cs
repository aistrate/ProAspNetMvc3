using System.Web;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class OrAuthorizatinAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Request.IsLocal || base.AuthorizeCore(httpContext);
            //return base.AuthorizeCore(httpContext);
        }
    }
}