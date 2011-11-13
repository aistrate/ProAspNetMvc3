using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValdation.Models
{
    public class Appointment4
    {
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }
}