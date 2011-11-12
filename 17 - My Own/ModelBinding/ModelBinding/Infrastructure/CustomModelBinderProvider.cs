using System;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Infrastructure
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            return modelType == typeof(Person) ? new PersonModelBinder() : null;
        }
    }
}