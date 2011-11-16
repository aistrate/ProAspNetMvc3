using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers {
    public class HomeController : Controller {


        public ActionResult Index() {

            IEnumerable<Summit> data = (IEnumerable<Summit>)Session["summits"];
            if (data == null) {
                data = CreateSummits();
                Session["summits"] = data;
            }
            
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteSummit(string name) {

            IEnumerable<Summit> data = (IEnumerable<Summit>)Session["summits"];
            Session["summits"] = data.Where(s => s.Name != name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ResetSummits() {
            Session["summits"] = CreateSummits();
            return RedirectToAction("Index");
        }

        public ViewResult AddSummit() {
            return View();
        }

        [HttpPost]
        public ActionResult AddSummit(Summit summit) {
            Session["summits"] = ((IEnumerable<Summit>)Session["summits"]).Concat(new Summit[] { summit });
            return RedirectToAction("Index");
        }

        private IEnumerable<Summit> CreateSummits() {
            return new[] {
                new Summit {Name = "Everest", Height = 8848},
                new Summit {Name = "Aconcagua", Height = 6962}, 
                new Summit {Name = "McKinley", Height = 6194},
                new Summit {Name = "Kilimanjaro", Height = 5895},
                new Summit {Name = "K2", Height = 8611}
            };
        }
    }
}
