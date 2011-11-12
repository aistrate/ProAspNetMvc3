using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Infrastructure {
    public class SimpleModelBinder : IModelBinder {


        public object BindModel(ControllerContext controllerContext, 
            ModelBindingContext bindingContext) {
                return 23;
        }
    }
}