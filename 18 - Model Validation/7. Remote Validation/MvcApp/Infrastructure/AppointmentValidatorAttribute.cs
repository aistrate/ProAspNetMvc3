using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Infrastructure {

public class AppointmentValidatorAttribute : ValidationAttribute {

    public AppointmentValidatorAttribute() {
        ErrorMessage = "Joe cannot book appointments on Mondays";
    }

    public override bool IsValid(object value) {

        Appointment app = value as Appointment;

        if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null) {
            // we don't have a model of the right type to validate, or we don't have
            // the values for the ClientName and Date properties we require
            return true;
        } else {
            return !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);
        } 
    }
}
}
