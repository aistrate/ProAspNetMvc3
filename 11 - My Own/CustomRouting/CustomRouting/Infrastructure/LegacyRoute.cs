using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomRouting.Infrastructure
{
    public class LegacyRoute : RouteBase
    {
        private string[] targetUrls;

        public LegacyRoute(params string[] targetUrls)
        {
            this.targetUrls = targetUrls;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            string requestedUrl = httpContext.Request.AppRelativeCurrentExecutionFilePath;

            if (targetUrls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                RouteData routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Legacy");
                routeData.Values.Add("action", "GetLegacyUrl");
                routeData.Values.Add("legacyUrl", requestedUrl);

                return routeData;
            }
            else
                return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (values.ContainsKey("legacyUrl") &&
                targetUrls.Contains((string)values["legacyUrl"], StringComparer.OrdinalIgnoreCase))
                return new VirtualPathData(
                                this,
                                new UrlHelper(requestContext).Content((string)values["legacyUrl"]).Substring(1));
            else
                return null;
        }
    }
}