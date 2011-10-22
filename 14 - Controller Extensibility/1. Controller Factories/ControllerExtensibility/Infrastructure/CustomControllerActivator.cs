using System;
using System.Web.Mvc;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure {

    public class CustomControllerActivator : IControllerActivator {

        public IController Create(System.Web.Routing.RequestContext requestContext, 
            Type controllerType) {

            if (controllerType == typeof(FirstController)) {
                controllerType = typeof(SecondController);
            }

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}