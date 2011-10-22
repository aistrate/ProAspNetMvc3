using System.Web.Mvc;
using ActionInvokers.Infrastructure;

namespace ActionInvokers.Controllers {

    public class CustomActionInvokerController : Controller {
        
        public CustomActionInvokerController() {
            this.ActionInvoker = new CustomActionInvoker();
        }
    }
}
