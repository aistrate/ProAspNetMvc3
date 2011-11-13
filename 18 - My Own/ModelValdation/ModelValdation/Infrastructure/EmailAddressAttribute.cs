using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ModelValdation.Infrastructure
{
    public class EmailAddressAttribute : ValidationAttribute, IClientValidatable
    {
        private static readonly Regex emailRegex = new Regex(@".+@.+\..+");

        public EmailAddressAttribute()
        {
            ErrorMessage = "Enter a valid email address [attribute]";
        }

        public override bool IsValid(object value)
        {
            return !string.IsNullOrWhiteSpace((string)value) &&
                   emailRegex.IsMatch((string)value);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]
            {
                new ModelClientValidationRule
                {
                    ValidationType = "required",
                    ErrorMessage = this.ErrorMessage + " [client]",
                },
                new ModelClientValidationRule
                {
                    ValidationType = "email",
                    ErrorMessage = this.ErrorMessage + " [client]",
                },
            };
        }
    }
}