using System.Web.Mvc;
using System.Web.Routing;
using URLsAndRoutes.Infrastructure;

namespace URLsAndRoutes {
    
    public class MvcApplication : System.Web.HttpApplication {

protected void Application_Start() {
    AreaRegistration.RegisterAllAreas();

    //ControllerBuilder.Current.DefaultNamespaces.Add("AdditionalControllers");
    ControllerBuilder.Current.DefaultNamespaces.Add("URLsAndRoutes.Controllers.*");

    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);
}

public static void RegisterRoutes(RouteCollection routes) {

    routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional });

    //routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}",
    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    //    new[] { "AdditionalControllers" });

    //Route myRoute = routes.MapRoute("AddContollerRoute", "Home/{action}/{id}/{*catchall}",
    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    //    new[] { "AdditionalControllers" });


    //myRoute.DataTokens["UseNamespaceFallback"] = false;



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