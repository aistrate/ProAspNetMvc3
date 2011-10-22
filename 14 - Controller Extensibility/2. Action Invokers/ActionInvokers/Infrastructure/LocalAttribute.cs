using System.Reflection;
using System.Web.Mvc;

namespace ActionInvokers.Infrastructure {
    public class LocalAttribute : ActionMethodSelectorAttribute {

        public override bool IsValidForRequest(ControllerContext context, 
            MethodInfo methodInfo) {

            return context.HttpContext.Request.IsLocal;   
        }
    }
}