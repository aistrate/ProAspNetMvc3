using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = (Person)(bindingContext.Model ?? DependencyResolver.Current.GetService(typeof(Person)));

            bool hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
            string prefix = hasPrefix ? bindingContext.ModelName + "." : "";

            model.PersonId = int.Parse(getValue(bindingContext, prefix, "PersonId"));
            model.FirstName = getValue(bindingContext, prefix, "FirstName");
            model.LastName = getValue(bindingContext, prefix, "LastName");
            model.BirthDate = DateTime.Parse(getValue(bindingContext, prefix, "BirthDate"));
            model.IsApproved = getBooleanValue(bindingContext, prefix, "IsApproved");
            model.Role = (Role)Enum.Parse(typeof(Role), getValue(bindingContext, prefix, "Role"));

            return model;
        }

        private string getValue(ModelBindingContext bindingContext, string prefix, string key)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(prefix + key);

            return value != null ? value.AttemptedValue : null;
        }

        private bool getBooleanValue(ModelBindingContext bindingContext, string prefix, string key)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(prefix + key);

            return value != null ? (bool)value.ConvertTo(typeof(bool)) : false;
        }
    }
}