using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ModelTemplates.Models
{
    public class PersonMetadataSource
    {
        [HiddenInput(DisplayValue = true)]
        public int PersonId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }
    }
}