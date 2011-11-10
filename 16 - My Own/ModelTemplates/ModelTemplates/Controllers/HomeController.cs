using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelTemplates.Models;

namespace ModelTemplates.Controllers
{
    public class HomeController : Controller
    {
        private Person testPerson = new Person
        {
            PersonId = 1,
            FirstName = "Joe",
            LastName = "Smith",
            BirthDate = new DateTime(1970, 4, 18),
            IsApproved = true,
            Role = Role.User,

            HomeAddress = new Address
            {
                Line1 = "123 North Street",
                Line2 = "West Bridge",
                City = "London",
                PostalCode = "W2C R1S",
                Country = "UK",
            }
        };

        private GeneratedPerson testGeneratedPerson = new GeneratedPerson
        {
            PersonId = 2,
            FirstName = "Alice",
            LastName = "Cooper",
            BirthDate = new DateTime(1965, 3, 1),
            IsApproved = true,
            Role = Role.Admin,
        };

        private SimpleModel simpleModel = new SimpleModel
        {
            Name = "John",
            Status = Role.Guest,
        };

        public ActionResult Index()
        {
            return View("EditorFor", testPerson);
        }

        public ActionResult EditorFor()
        {
            return View(testPerson);
        }

        public ActionResult DisplayFor()
        {
            return View(testPerson);
        }

        public ActionResult LabelFor()
        {
            return View(testPerson);
        }

        public ActionResult DisplayTextFor()
        {
            return View(testPerson);
        }

        public ActionResult EditorForModel()
        {
            return View(testPerson);
        }

        public ActionResult DisplayForModel()
        {
            return View(testPerson);
        }

        public ActionResult LabelForModel()
        {
            return View(testPerson);
        }

        public ActionResult EditGeneratedPerson()
        {
            return View(testGeneratedPerson);
        }

        public ActionResult RoleTest()
        {
            return View(testPerson);
        }

        public ActionResult SimpleModelTest()
        {
            return View(simpleModel);
        }
    }
}
