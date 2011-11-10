using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace MVCApp.Models {

public partial class Person {

    [HiddenInput(DisplayValue=false)]
    public int PersonId { get; set; }
    public string FirstName { get; set; }    
    public string LastName { get; set; }

[DataType(DataType.Date)]
public DateTime BirthDate { get; set; }

    public Address HomeAddress { get; set; }

    [AdditionalMetadata("RenderList", "true")]
    public bool IsApproved { get; set; }

    [UIHint("Enum")]
    public Role Role { get; set; }
}

public class Address {

    public string Line1 { get; set; }

    public string Line2 { get; set; }

    public string City { get; set; }

    public string PostalCode { get; set; }

    public string Country { get; set; }
}

public enum Role {
    Admin,
    User,
    Guest
}
}