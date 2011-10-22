using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure {
    public class CustomControllerFactory : IControllerFactory {

        public IController CreateController(RequestContext requestContext, 
            string controllerName) {
            Type targetType = null;
            switch (controllerName) {
                case "Home":
                    requestContext.RouteData.Values["controller"] = "First";
                    targetType = typeof(FirstController);
                    break;
                case "First":
                    targetType = typeof(FirstController);
                    break;
                case "Second":
                    targetType = typeof(SecondController);
                    break;
            }

            return targetType == null ? 
                null : (IController)Activator.CreateInstance(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(
            RequestContext requestContext, string controllerName) {

            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller) {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null) {
                disposable.Dispose();
            }
        }
    }
}