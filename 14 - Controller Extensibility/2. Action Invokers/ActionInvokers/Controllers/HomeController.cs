using System.Web.Mvc;
using ActionInvokers.Infrastructure;

namespace ActionInvokers.Controllers {

public class StaffController : Controller {
    
    [HttpGet]
    [ActionName("Staff")]
    public ActionResult StaffGet(int id) {

        // ... logic to get and return data item

        return View();
    }

    [HttpPost]
    [ActionName("Staff")]
    public ActionResult StaffModify(int id, StaffMember person) {

        // ... logic to modify or create data item

        return View();
    }

    [HttpDelete]
    [ActionName("Staff")]
    public ActionResult StaffDelete(int id) {

        // ... logic to delete data item

        return View();
    }


}

    public class StaffMember {

    }

}
