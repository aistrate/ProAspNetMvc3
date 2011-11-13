using System;
using System.ComponentModel.DataAnnotations;
using MvcApp.Infrastructure;
using System.Web.Mvc;

namespace MvcApp.Models {

    [AppointmentValidator]
    public class Appointment {

        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage="Please enter a date in the future")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage="You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}