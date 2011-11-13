using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models {

public class Appointment {

    public string ClientName { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public bool TermsAccepted { get; set; }
}
}