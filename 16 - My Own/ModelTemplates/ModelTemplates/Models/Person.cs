using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace ModelTemplates.Models
{
    public enum Role
    {
        Admin,
        User,
        Guest,
    }

    [DisplayName("Person Details")]
    public class Person
    {
        //[ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = true)]
        public int PersonId { get; set; }

        //[UIHint("MultilineText")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Date of Birth")]
        public DateTime BirthDate { get; set; }

        public Address HomeAddress { get; set; }

        [AdditionalMetadata("RenderList", true)]
        public bool IsApproved { get; set; }

        //[UIHint("Enum")]
        public Role Role { get; set; }
    }
}