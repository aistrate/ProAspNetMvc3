using System;
using System.ComponentModel;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Infrastructure {
    public class ValidatingModelBinder : DefaultModelBinder {

        protected override void SetProperty(ControllerContext controllerContext, 
            ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, 
            object value) {

            // make sure we call the base implementation
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);

            // perform our property-level validation
            switch (propertyDescriptor.Name) {
                case "ClientName":
                    if (string.IsNullOrEmpty((string)value)) {
                        bindingContext.ModelState.AddModelError("ClientName", 
                            "Please enter your name");
                    }
                    break;
                case "Date":
                    if (bindingContext.ModelState.IsValidField("Date") && 
                        DateTime.Now > ((DateTime)value)) {
                        bindingContext.ModelState.AddModelError("Date", 
                            "Please enter a date in the future");
                    }
                    break;
                case "TermsAccepted":
                    if (!((bool)value)) {
                        bindingContext.ModelState.AddModelError("TermsAccepted", 
                            "You must accept the terms");
                    }
                    break;
            }
        }

        protected override void OnModelUpdated(ControllerContext controllerContext,
            ModelBindingContext bindingContext) {

            // make sure we call the base implementation
            base.OnModelUpdated(controllerContext, bindingContext);

            // get the model
            Appointment model = bindingContext.Model as Appointment;

            // apply our model-level validation
            if (model != null &&
                bindingContext.ModelState.IsValidField("ClientName") &&
                bindingContext.ModelState.IsValidField("Date") &&
                model.ClientName == "Joe" &&
                model.Date.DayOfWeek == DayOfWeek.Monday) {
                bindingContext.ModelState.AddModelError("",
                    "Joe cannot book appointments on Mondays");
            }
        }
    }
}