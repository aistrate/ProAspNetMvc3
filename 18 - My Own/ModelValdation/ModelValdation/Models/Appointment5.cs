using System;
using System.ComponentModel.DataAnnotations;
using ModelValdation.Infrastructure;
using System.Web.Mvc;

namespace ModelValdation.Models
{
    public class Appointment5
    {
        [Required(ErrorMessage = "Please enter your name [model]")]
        [StringLength(10, MinimumLength=3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date [model]")]
        [Remote("ValidateDate", "Appointment")]
        public DateTime Date { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms [model]")]
        public bool TermsAccepted { get; set; }
    }
}