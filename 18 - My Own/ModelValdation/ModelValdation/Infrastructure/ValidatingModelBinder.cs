using System;
using System.ComponentModel;
using System.Web.Mvc;
using ModelValdation.Models;

namespace ModelValdation.Infrastructure
{
    public class ValidatingModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor,
            object value)
        {
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);

            switch (propertyDescriptor.Name)
            {
                case "ClientName":
                    if (string.IsNullOrWhiteSpace((string)value))
                        bindingContext.ModelState.AddModelError("ClientName", "Please enter your name [binder]");
                    break;

                case "Date":
                    if (bindingContext.ModelState.IsValidField("Date") && DateTime.Now.Date > (DateTime)value)
                        bindingContext.ModelState.AddModelError("Date", "Please enter a date in the future [binder]");
                    break;

                case "TermsAccepted":
                    if (!(bool)value)
                        bindingContext.ModelState.AddModelError("TermsAccepted", "You must accept the terms [binder]");
                    break;
            }
        }

        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);

            Appointment model = bindingContext.Model as Appointment;

            if (model != null &&
                bindingContext.ModelState.IsValidField("ClientName") &&
                bindingContext.ModelState.IsValidField("Date") &&
                model.ClientName == "Joe" &&
                model.Date.DayOfWeek == DayOfWeek.Monday)
                bindingContext.ModelState.AddModelError("", "Joe cannot book appointments on Mondays [binder]");
        }
    }
}