using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.Filters
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private string[] allowedUsers;

        public CustomAuthAttribute(params string[] allowedUsers)
        {
            this.allowedUsers = allowedUsers;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Request.IsAuthenticated &&
                   allowedUsers.Contains(httpContext.User.Identity.Name,
                                         StringComparer.InvariantCultureIgnoreCase);
        }
    }
}