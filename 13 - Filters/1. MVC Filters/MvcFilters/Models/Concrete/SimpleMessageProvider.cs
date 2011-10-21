using MvcFilters.Models.Abstract;

namespace MvcFilters.Models.Concrete {

public class SimpleMessageProvider : IMessageProvider {

    public string Message {
        get {
            return "Hello DI";
        }
    }
}
}