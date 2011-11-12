using System;
using System.Web.Mvc;

namespace MvcApp.Infrastructure {
    public class DIModelBinder : DefaultModelBinder {

        protected override object CreateModel(ControllerContext controllerContext, 
            ModelBindingContext bindingContext, Type modelType) {

            return DependencyResolver.Current.GetService(modelType)??
                base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}