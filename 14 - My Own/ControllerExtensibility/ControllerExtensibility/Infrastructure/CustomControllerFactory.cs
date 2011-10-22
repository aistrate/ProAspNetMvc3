using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = null;

            switch (controllerName)
            {
                case "Home":
                    controllerType = typeof(FirstController);
                    requestContext.RouteData.Values["controller"] = "First";
                    break;
                case "First":
                    controllerType = typeof(FirstController);
                    break;
                case "Second":
                    controllerType = typeof(SecondController);
                    break;
            }

            return controllerType != null ? (IController)Activator.CreateInstance(controllerType) : null;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}