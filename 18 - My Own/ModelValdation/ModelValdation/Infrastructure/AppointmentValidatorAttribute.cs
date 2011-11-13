using System;
using System.ComponentModel.DataAnnotations;
using ModelValdation.Models;

namespace ModelValdation.Infrastructure
{
    public class AppointmentValidatorAttribute : ValidationAttribute
    {
        public AppointmentValidatorAttribute()
        {
            ErrorMessage = "Joe cannot book appointments on Mondays [attribute]";
        }

        public override bool IsValid(object value)
        {
            Appointment appointment = value as Appointment;

            if (appointment == null ||
                string.IsNullOrWhiteSpace(appointment.ClientName) ||
                appointment.Date == null)
                return true;
            else
                return !(appointment.ClientName == "Joe" && appointment.Date.DayOfWeek == DayOfWeek.Monday);
        }
    }
}