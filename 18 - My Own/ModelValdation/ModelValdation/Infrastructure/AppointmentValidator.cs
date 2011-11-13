using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelValdation.Models;

namespace ModelValdation.Infrastructure
{
    public class AppointmentValidator : ModelValidator
    {
        public AppointmentValidator(ModelMetadata metadata,
                                    ControllerContext controllerContext)
            : base(metadata, controllerContext)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Appointment4 appointment = Metadata.Model as Appointment4;

            if (appointment != null &&
                appointment.ClientName == "Joe" &&
                appointment.Date.DayOfWeek == DayOfWeek.Monday)
                return new[]
                {
                    new ModelValidationResult
                    {
                        MemberName = "",
                        Message = "Joe cannot book appointments on Mondays [validator]",
                    }
                };

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}