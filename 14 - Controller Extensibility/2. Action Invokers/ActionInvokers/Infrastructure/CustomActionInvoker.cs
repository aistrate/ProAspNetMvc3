using System.Web.Mvc;

namespace ActionInvokers.Infrastructure {
    public class CustomActionInvoker : IActionInvoker {

        public bool InvokeAction(ControllerContext context, string actionName) {
            if (actionName == "Index") {
                context.HttpContext.Response.Write("This is output from the Index action");
                return true;
            } else {
                return false;
            }
        }
    }
}