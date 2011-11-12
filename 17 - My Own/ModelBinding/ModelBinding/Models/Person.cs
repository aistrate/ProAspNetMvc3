using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ModelBinding.Infrastructure;

namespace ModelBinding.Models
{
    public enum Role
    {
        Admin,
        User,
        Guest,
    }

    [Bind(Exclude="IsApproved")]
    //[ModelBinder(typeof(PersonModelBinder))]
    public class Person
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        public Role Role { get; set; }
    }
}