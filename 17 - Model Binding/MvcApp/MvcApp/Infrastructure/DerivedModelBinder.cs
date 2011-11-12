using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Infrastructure {
    public class DerivedModelBinder : DefaultModelBinder {

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {

            

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}