using System;
using System.Globalization;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
    public class CurrentTimeValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("CurrentTime", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            return ContainsPrefix(key) ?
                new ValueProviderResult(DateTime.Now, null, CultureInfo.InvariantCulture) :
                null;
        }
    }
}