using System;
using System.ComponentModel.DataAnnotations;
using ModelValdation.Infrastructure;

namespace ModelValdation.Models
{
    [AppointmentValidator]
    public class Appointment
    {
        [Required(ErrorMessage="Please enter your name [model]")]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage="Please enter a date [model]")]
        //[Range(typeof(DateTime), "12-11-2011", "01-01-2100",
        //       ErrorMessage = "Please enter a date in the future [model]")]
        [FutureDate(ErrorMessage = "Please enter a date in the future [model]")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage="You must accept the terms [model]")]
        [MustBeTrue(ErrorMessage = "You must accept the terms [model]")]
        public bool TermsAccepted { get; set; }
    }
}