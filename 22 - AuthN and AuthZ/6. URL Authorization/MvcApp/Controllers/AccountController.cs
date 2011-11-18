using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApp.Controllers {
    public class AccountController : Controller {

        public ViewResult LogOn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(string username, string password, string returnUrl) {

            if (ModelState.IsValid) {
                if (Membership.ValidateUser(username, password)) {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                } else {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            } else {
                return View();
            }
        }
    }
}
