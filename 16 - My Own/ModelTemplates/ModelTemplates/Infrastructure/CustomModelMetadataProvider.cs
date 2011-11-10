using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelTemplates.Infrastructure
{
    public class CustomModelMetadataProvider : AssociatedMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            ModelMetadata metadata = new ModelMetadata(this, containerType, modelAccessor, modelType, propertyName);

            if (propertyName != null && propertyName.EndsWith("Name"))
                metadata.DisplayName = propertyName.Substring(0, propertyName.Length - 4);

            return metadata;
        }
    }
}