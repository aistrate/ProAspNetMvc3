using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelValdation.Models
{
    public class Appointment3 : IValidatableObject
    {
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(ClientName))
                errors.Add(new ValidationResult("Please enter your name", new[] { "ClientName" }));

            if (DateTime.Now.Date > Date)
                errors.Add(new ValidationResult("Please enter a date in the future", new[] { "Date" }));

            if (errors.Count == 0 &&
                ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
                errors.Add(new ValidationResult("Joe cannot book appointments on Mondays"));

            if (!TermsAccepted)
                errors.Add(new ValidationResult("You must accept the terms", new[] { "TermsAccepted" }));

            return errors;
        }
    }
}