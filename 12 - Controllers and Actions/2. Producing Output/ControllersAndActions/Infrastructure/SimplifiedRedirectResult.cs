using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Infrastructure {

public class SimplifiedRedirectResult : ActionResult {
 
    public SimplifiedRedirectResult(string url): this(url, permanent: false) {
    }

    public SimplifiedRedirectResult(string url, bool permanent) {
        Permanent = permanent;
        Url = url;
    }

    public bool Permanent {
        get;
        private set;
    }

    public string Url {
        get;
        private set;
    }

    public override void ExecuteResult(ControllerContext context) {
        string destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
        context.Controller.TempData.Keep();

        if (Permanent) {
            context.HttpContext.Response.RedirectPermanent(
                destinationUrl, endResponse: false);
        }
        else {
            context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
        }
    }
}
}