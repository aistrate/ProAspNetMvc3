using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndActions.Controllers
{
    public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Redirect("/Some/Other/Url");

            Func<string, string> routeValue =
                routeVar => (string)requestContext.RouteData.Values[routeVar];

            string controller = routeValue("controller"),
                   action = routeValue("action");

            requestContext.HttpContext.Response.Write(
                string.Format("Controller: {0}, Action: {1}", controller, action));
        }
    }
}