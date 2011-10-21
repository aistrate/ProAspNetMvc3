using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcFilters.Infrastructure.FilterProviders {

public class CustomFilterProvider : IFilterProvider {
    private IList<CustomFilterWrapper> wrappers;

    public CustomFilterProvider() {
        wrappers = new List<CustomFilterWrapper>();
    }

    public IList<CustomFilterWrapper> Wrappers {
        get { return wrappers; }
    }

    public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, 
        ActionDescriptor actionDescriptor) {

        return wrappers.Where(e => e.Selector(controllerContext, actionDescriptor));
    }
}

public class CustomFilterWrapper : Filter {

    public CustomFilterWrapper(object instance, FilterScope scope, int? order
        , Func<ControllerContext, ActionDescriptor, bool> selector)
        : base(instance, scope, order) {
        Selector = selector;
    }

    public Func<ControllerContext, ActionDescriptor, bool> Selector {
        get;
        set;
    }
}
}