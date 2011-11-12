using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
    public class DIModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            Type modelType)
        {
            return DependencyResolver.Current.GetService(modelType) ??
                        base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}