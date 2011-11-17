using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcApp.Infrastructure;
using System.Web.Mvc;

namespace MvcApp.Models {

public class Appointment {
    
    //[AllowHtml]
    public string ClientName { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public bool TermsAccepted { get; set; }
}
}