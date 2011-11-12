using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
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

        private Person[] personColl = new[]
            {
                new Person { FirstName = "Bill", LastName = "Gates" },
                new Person { FirstName = "Steve", LastName = "Jobs" },
                new Person { FirstName = "Larry", LastName = "Ellison" },
                new Person { FirstName = "Paul", LastName = "Graham" },
            };

        [HttpGet]
        public ActionResult EditPerson()
        {
            return View(testPerson);
        }

        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            return View(person);
        }

        [HttpGet]
        public ActionResult EditPerson2()
        {
            return View(testPerson);
        }

        [HttpPost]
        //public ActionResult EditPerson2(Person firstPerson, Person myPerson)
        public ActionResult EditPerson2(Person firstPerson,
                                        [Bind(Prefix="myPerson")] Person secondPerson)
        {
            return View(firstPerson);
        }

        [HttpGet]
        public ActionResult EditPerson3()
        {
            return View(testPerson);
        }

        [HttpPost]
        //public ActionResult EditPerson3([Bind(Include = "FirstName, LastName")] Person person)
        //public ActionResult EditPerson3([Bind(Exclude = "IsApproved, Role")] Person person)
        public ActionResult EditPerson3(Person person)
        {
            return View(testPerson);
        }

        [HttpGet]
        public ActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Movies(string[] movies)
        {
            return View();
        }

        [HttpGet]
        public ActionResult PersonList()
        {
            return View(personColl);
        }

        [HttpPost]
        public ActionResult PersonList(Person[] persons)
        {
            return View(persons);
        }

        [HttpGet]
        public ActionResult PersonList2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonList2(Person[] persons)
        {
            return View();
        }

        [HttpGet]
        public ActionResult PersonList3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonList3(IDictionary<string, Person> persons)
        {
            return View();
        }

        [HttpGet]
        [ActionName("RegisterMember")]
        public ActionResult CreateMember()
        {
            return View("RegisterMember", new Person());
        }

        [HttpPost]
        public ActionResult RegisterMember()
        {
            Person person = new Person();
            //UpdateModel(person);
            //UpdateModel(person, new QueryStringValueProvider(ControllerContext));
            UpdateModel(person, new FormValueProvider(ControllerContext));
            return View(person);
        }

        [HttpGet]
        [ActionName("RegisterMember2")]
        public ActionResult CreateMember2()
        {
            return View("RegisterMember", new Person());
        }

        [HttpPost]
        public ActionResult RegisterMember2(FormCollection formData)
        {
            Person person = new Person();
            UpdateModel(person, formData);
            return View("RegisterMember", person);
        }

        [HttpGet]
        [ActionName("RegisterMember3")]
        public ActionResult CreateMember3()
        {
            return View("RegisterMember", new Person());
        }

        [HttpPost]
        public ActionResult RegisterMember3(FormCollection formData)
        {
            Person person = new Person();

            try
            {
                UpdateModel(person, formData);
            }
            catch (InvalidOperationException ex)
            {
                //return Content(ex.Message);
            }

            return View("RegisterMember", person);
        }

        [HttpGet]
        [ActionName("RegisterMember4")]
        public ActionResult CreateMember4()
        {
            return View("RegisterMember", new Person());
        }

        [HttpPost]
        public ActionResult RegisterMember4(FormCollection formData)
        {
            Person person = new Person();

            TryUpdateModel(person, formData);

            return View("RegisterMember", person);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                byte[] uploadedFile = new byte[photo.ContentLength];
                photo.InputStream.Read(uploadedFile, 0, photo.ContentLength);

                //return Content(new string(Encoding.UTF8.GetChars(uploadedFile)), "text/plain");
                return File(uploadedFile, photo.ContentType);
            }
            else
                return View();
        }
    }
}
