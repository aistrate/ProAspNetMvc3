using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UnobtrusiveAjax.Models;

namespace UnobtrusiveAjax.Controllers
{
    public class AppointmentController : Controller
    {
        private static Appointment[] appointments = new[]
        {
            new Appointment { ClientName = "Joe", Date = new DateTime(2012, 1, 1) },
            new Appointment { ClientName = "Joe", Date = new DateTime(2012, 2, 1) },
            new Appointment { ClientName = "Joe", Date = new DateTime(2012, 3, 1) },
            new Appointment { ClientName = "Jane", Date = new DateTime(2012, 1, 20) },
            new Appointment { ClientName = "Jane", Date = new DateTime(2012, 1, 22) },
            new Appointment { ClientName = "Bob", Date = new DateTime(2012, 2, 25) },
            new Appointment { ClientName = "Bob", Date = new DateTime(2013, 2, 25) },
        };

        public ActionResult Index(string name)
        {
            return View((object)name);
        }

        public ActionResult AppointmentList(string name)
        {
            IEnumerable<Appointment> filteredAppointments =
                !string.IsNullOrEmpty(name) && name != "All" ?
                    appointments.Where(a => a.ClientName == name) :
                    appointments;

            if (Request.IsAjaxRequest())
                return Json(filteredAppointments.Select(a => new
                            {
                                ClientName = a.ClientName,
                                Date = a.Date.ToShortDateString(),
                            }),
                            JsonRequestBehavior.AllowGet);
            else
                return View(filteredAppointments);
        }

        public ActionResult CreateNew()
        {
            return View(new Appointment());
        }

        [HttpPost]
        public ActionResult CreateNew(Appointment appointment)
        {
            if (Request.IsAjaxRequest())
                return Json(new
                            {
                                appointment.ClientName,
                                Date = appointment.Date.ToShortDateString(),
                                appointment.TermsAccepted,
                            });
            else
                return View();
        }
    }
}
