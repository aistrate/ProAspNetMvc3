using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcApp.Infrastructure;
using MvcApp.Models;

namespace MvcApp {
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
                new { controller = "Appointment", action = "MakeBooking", id = UrlParameter.Optional } // Parameter defaults
            );

        }

protected void Application_Start() {
    AreaRegistration.RegisterAllAreas();

    DependencyResolver.SetResolver(new NinjectDependencyResolver());

    //ModelBinders.Binders.Add(typeof(Appointment), new ValidatingModelBinder());

    //ModelValidatorProviders.Providers.Clear();
    //ModelValidatorProviders.Providers.Add(new CustomValidationProvider());

    //HtmlHelper.ClientValidationEnabled = true;
    //HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);
}
    }
}