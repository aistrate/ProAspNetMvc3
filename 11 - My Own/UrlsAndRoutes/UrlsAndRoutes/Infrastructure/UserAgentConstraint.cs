using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Infrastructure
{
    public class UserAgentConstraint : IRouteConstraint
    {
        private string userAgent;

        public UserAgentConstraint(string userAgent)
        {
            this.userAgent = userAgent;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent != null &&
                   httpContext.Request.UserAgent.ToLower().Contains(userAgent.ToLower());
        }
    }
}