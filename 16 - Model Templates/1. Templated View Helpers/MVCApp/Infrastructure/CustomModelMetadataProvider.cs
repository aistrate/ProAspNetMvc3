using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCApp.Infrastructure {
public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider {

    protected override ModelMetadata CreateMetadata(
        IEnumerable<Attribute> attributes, 
        Type containerType, 
        Func<object> modelAccessor, 
        Type modelType, 
        string propertyName) {

        ModelMetadata metadata = base.CreateMetadata(attributes, containerType, 
            modelAccessor, modelType, propertyName);

        if (propertyName != null && propertyName.EndsWith("Name")) {
            metadata.DisplayName = propertyName.Substring(0, propertyName.Length - 4);
        }

        return metadata;
    }
}
}