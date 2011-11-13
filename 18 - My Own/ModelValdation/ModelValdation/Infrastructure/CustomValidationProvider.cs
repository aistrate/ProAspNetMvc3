using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelValdation.Models;

namespace ModelValdation.Infrastructure
{
    public class CustomValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(Appointment4))
                return new[] { new AppointmentPropertyValidator(metadata, context) };
            else if (metadata.ModelType == typeof(Appointment4))
                return new[] { new AppointmentValidator(metadata, context) };
            else
                return Enumerable.Empty<ModelValidator>();
        }
    }
}