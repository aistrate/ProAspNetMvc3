using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;
using System.ComponentModel;

namespace MVCApp.Controllers {
    public class HomeController : Controller {
       
        public ActionResult Index() {

            Person myPerson = new Person {
                PersonId = 1,
                FirstName = "Joe",
                LastName = "Smith",
                BirthDate = DateTime.Parse("25/02/75"),
                HomeAddress = new Address {
                    Line1 = "123 North Street",
                    Line2 = "West Bridge",
                    City = "London",
                    Country = "UK",
                    PostalCode = "WC2R 1SS"
                },
                IsApproved = true,
                Role = Role.User
            };
            return View(myPerson);
        }

        public ActionResult SimpleModel() {
            return View(new SimpleModel {
                Name = "Joe Smith",
                Status = Role.Guest
            });
        }

    }
}
