using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Infrastructure {
    public class ClientValidationAttribute : ValidationAttribute, IClientValidatable {
        private string validationType, errorMessage;

        public ClientValidationAttribute(string valType, string error) {
            validationType = valType;
            errorMessage = error;
        }

        public override bool IsValid(object value) {
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {
            return new ModelClientValidationRule[] {new ModelClientValidationRule {
                ValidationType = validationType,
                ErrorMessage = errorMessage
            }};
        }
    }
}