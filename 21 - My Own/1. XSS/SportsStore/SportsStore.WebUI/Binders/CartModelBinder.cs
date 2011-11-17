using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var session = controllerContext.HttpContext.Session;

            Cart cart = (Cart)session[sessionKey];

            if (cart == null)
            {
                cart = new Cart();
                session[sessionKey] = cart;
            }

            return cart;
        }
    }
}