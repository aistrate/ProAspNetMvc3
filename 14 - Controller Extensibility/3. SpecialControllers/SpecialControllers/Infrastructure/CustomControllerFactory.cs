using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SpecialControllers.Controllers;
using System.Web.SessionState;

namespace SpecialControllers.Infrastructure {

    public class CustomControllerFactory : IControllerFactory {

        public IController CreateController(RequestContext requestContext,
            string controllerName) {

            Type targetType = null;
            switch (controllerName) {
                case "Home":
                    targetType = typeof(HomeController);
                    break;
                case "Other":
                    targetType = typeof(OtherController);
                    break;
            }

            return targetType == null ?
                null : (IController)Activator.CreateInstance(targetType);
        }

public SessionStateBehavior GetControllerSessionBehavior(
    RequestContext requestContext, string controllerName) {

    switch (controllerName) {
        case "Home":
            return SessionStateBehavior.ReadOnly;
        case "Other":
            return SessionStateBehavior.Required;
        default:
            return SessionStateBehavior.Default;
    }
}

        public void ReleaseController(IController controller) {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null) {
                disposable.Dispose();
            }
        }
    }
}
