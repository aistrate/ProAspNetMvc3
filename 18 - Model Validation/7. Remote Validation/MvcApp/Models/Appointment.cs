using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcApp.Infrastructure;
using System.Web.Mvc;

namespace MvcApp.Models {

public class Appointment {

    //[Required]
    //[StringLength(10, MinimumLength=3)]
    //[ClientValidation("email", "Please enter a valid email address")]
    [EmailAddress]
    public string ClientName { get; set; }

    [DataType(DataType.Date)]
    //[Required(ErrorMessage="Please enter a date")]
    [Remote("ValidateDate", "Appointment")]
    public DateTime Date { get; set; }

    [MustBeTrue(ErrorMessage="You must accept the terms")]
    public bool TermsAccepted { get; set; }
}
}