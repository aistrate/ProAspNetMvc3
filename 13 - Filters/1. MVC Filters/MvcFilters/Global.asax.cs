using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcFilters.Infrastructure.Filters;
using MvcFilters.Infrastructure.FilterProviders;
using MvcFilters.Infrastructure;
using MvcFilters.Models.Abstract;
using MvcFilters.Models.Concrete;

namespace MvcFilters {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

public class MvcApplication : System.Web.HttpApplication {

public static void RegisterGlobalFilters(GlobalFilterCollection filters) {

    filters.Add(new HandleErrorAttribute());
    

    
}

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Example", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

protected void Application_Start() {
    AreaRegistration.RegisterAllAreas();

    DependencyResolver.SetResolver(new NinjectDependencyResolver());
   
    FilterProviders.Providers.Clear();
    FilterProviders.Providers.Add(new DIFilterProvider());

    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);
}
    }
}