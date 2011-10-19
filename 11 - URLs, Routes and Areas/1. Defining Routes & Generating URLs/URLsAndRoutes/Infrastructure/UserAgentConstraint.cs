using System.Web;
using System.Web.Routing;

namespace URLsAndRoutes.Infrastructure {

    public class UserAgentConstraint : IRouteConstraint {
        private string requiredUserAgent;

        public UserAgentConstraint(string agentParam) {
            requiredUserAgent = agentParam;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, 
                          RouteValueDictionary values, RouteDirection routeDirection) {

            bool result = httpContext.Request.UserAgent != null && 
                httpContext.Request.UserAgent.Contains(requiredUserAgent);
            return result;
        }
    }
}