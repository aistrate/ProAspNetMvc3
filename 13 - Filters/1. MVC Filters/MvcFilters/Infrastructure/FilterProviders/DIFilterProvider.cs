using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.FilterProviders {

    public class DIFilterProvider : FilterAttributeFilterProvider {

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, 
            ActionDescriptor actionDescriptor) {

            IEnumerable<Filter> filters = base.GetFilters(controllerContext, 
                actionDescriptor);

            NinjectDependencyResolver dependencyResolver 
                = DependencyResolver.Current as NinjectDependencyResolver;

            if (dependencyResolver != null) {
                foreach (Filter f in filters) {
                    dependencyResolver.Kernel.Inject(f.Instance);
                }
            }
            return filters;
        }
    }
}