using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelValdation.Models;

namespace ModelValdation.Infrastructure
{
    public class AppointmentPropertyValidator : ModelValidator
    {
        public AppointmentPropertyValidator(ModelMetadata metadata,
                                            ControllerContext controllerContext)
            : base(metadata, controllerContext)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Appointment4 appointment = container as Appointment4;

            if (appointment != null)
            {
                switch (Metadata.PropertyName)
                {
                    case "ClientName":
                        if (string.IsNullOrWhiteSpace(appointment.ClientName))
                            return new[]
                            {
                                new ModelValidationResult
                                {
                                    MemberName = "",
                                    Message = "Please enter your name [validator]",
                                }
                            };
                        break;

                    case "Date":
                        if (appointment.Date == null || DateTime.Now.Date > appointment.Date)
                            return new[]
                            {
                                new ModelValidationResult
                                {
                                    MemberName = "",
                                    Message = "Please enter a date in the future [validator]",
                                }
                            };
                        break;

                    case "TermsAccepted":
                        if (!appointment.TermsAccepted)
                            return new[]
                            {
                                new ModelValidationResult
                                {
                                    MemberName = "",
                                    Message = "You must accept the terms [validator]",
                                }
                            };
                        break;
                }
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}