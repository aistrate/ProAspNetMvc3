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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            return View((object)name);
        }

        public ViewResult AppointmentList(string name)
        {
            IEnumerable<Appointment> filteredAppointments =
                !string.IsNullOrEmpty(name) && name != "All" ?
                    appointments.Where(a => a.ClientName == name) :
                    appointments;

            return View(filteredAppointments);
        }

        // Unobtrusive JavaScript is disabled
        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index2(string name)
        {
            return View((object)name);
        }

        // Graceful degradation (when JavaScript is disabled)
        public ActionResult Index3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index3(string name)
        {
            return View((object)name);
        }
    }
}
