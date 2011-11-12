using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
    public class CurrentTimeValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CurrentTimeValueProvider();
        }
    }
}