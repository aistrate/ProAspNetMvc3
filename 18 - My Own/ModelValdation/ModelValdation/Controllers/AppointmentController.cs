using System;
using System.Web.Mvc;
using ModelValdation.Models;

namespace ModelValdation.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now.Date });
        }

        [HttpPost]
        public ActionResult MakeBooking(Appointment appointment)
        {
            if (string.IsNullOrWhiteSpace(appointment.ClientName))
                ModelState.AddModelError("ClientName", "Please enter your name [controller]");

            if (ModelState.IsValidField("Date") && DateTime.Now.Date > appointment.Date)
                ModelState.AddModelError("Date", "Please enter a date in the future [controller]");

            if (!appointment.TermsAccepted)
                ModelState.AddModelError("TermsAccepted", "You must accept the terms [controller]");

            if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date") &&
                appointment.ClientName == "Joe" && appointment.Date.DayOfWeek == DayOfWeek.Monday)
                ModelState.AddModelError("", "Joe cannot book appointments on Mondays [controller]");

            if (ModelState.IsValid)
            {
                // Save appointment
                // ...

                return View("Completed", appointment);
            }
            else
                return View();
        }

        public ActionResult MakeBooking2()
        {
            return View("MakeBooking", new Appointment { Date = DateTime.Now.Date });
        }

        [HttpPost]
        public ActionResult MakeBooking2(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                // Save appointment
                // ...

                return View("Completed", appointment);
            }
            else
                return View("MakeBooking");
        }

        public ActionResult MakeBooking3()
        {
            return View(new Appointment3 { Date = DateTime.Now.Date });
        }

        [HttpPost]
        public ActionResult MakeBooking3(Appointment3 appointment)
        {
            if (ModelState.IsValid)
            {
                // Save appointment
                // ...

                return View("Completed3", appointment);
            }
            else
                return View();
        }

        public ActionResult MakeBooking4()
        {
            return View(new Appointment4 { Date = DateTime.Now.Date });
        }

        [HttpPost]
        public ActionResult MakeBooking4(Appointment4 appointment)
        {
            if (ModelState.IsValid)
            {
                // Save appointment
                // ...

                return View("Completed4", appointment);
            }
            else
                return View();
        }

        public ActionResult MakeBooking5()
        {
            return View(new Appointment5 { Date = DateTime.Now.Date });
        }

        [HttpPost]
        public ActionResult MakeBooking5(Appointment5 appointment)
        {
            if (ModelState.IsValid)
            {
                // Save appointment
                // ...

                return View("Completed5", appointment);
                //return View();
            }
            else
                return View();
        }

        public JsonResult ValidateDate(string date)
        {
            DateTime parsedDate;

            if (!DateTime.TryParse(date, out parsedDate))
                return Json("Please enter a valid date (dd-mm-yyyy) [remote]", JsonRequestBehavior.AllowGet);
            else if (DateTime.Now.Date > parsedDate)
                return Json("Please enter a date in the future [remote]", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
