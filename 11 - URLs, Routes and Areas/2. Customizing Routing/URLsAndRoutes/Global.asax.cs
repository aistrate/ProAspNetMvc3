using System.Web.Mvc;
using System.Web.Routing;
using URLsAndRoutes.Infrastructure;

namespace URLsAndRoutes {
    
    public class MvcApplication : System.Web.HttpApplication {

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

public static void RegisterRoutes(RouteCollection routes) {

    routes.Add(new Route("SayHello", new CustomRouteHandler()));

    routes.Add(new LegacyRoute(
        "~/articles/Windows_3.1_Overview.html",
        "~/old/.NET_1.0_Class_Library"));

    routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional });





    //routes.RouteExistingFiles = true;

    //routes.MapRoute("DiskFile", "Content/StaticContent.html",
    //    new {
    //        controller = "Account", action = "LogOn",
    //    },
    //    new {
    //        customConstraint = new UserAgentConstraint("IE")
    //    });

    //routes.IgnoreRoute("Content/{filename}.html");

    //routes.MapRoute("", "{controller}/{action}");

    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    //    new {
    //        controller = "^H.*", action = "Index|About",
    //        httpMethod = new HttpMethodConstraint("GET", "POST"),
    //        customConstraint = new UserAgentConstraint("IE")
    //    },
    //    new[] { "URLsAndRoutes.Controllers" });
}

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}