using System.Web.Mvc;
using ControllerExtensibility.Infrastructure;

namespace ControllerExtensibility.Controllers {
    public class CustomActionInvokerController : Controller {

        public CustomActionInvokerController() {
            this.ActionInvoker = new CustomActionInvoker();
        }
    }
}
