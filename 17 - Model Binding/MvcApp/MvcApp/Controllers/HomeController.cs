using System;
using System.Web.Mvc;
using MvcApp.Models;
using System.Collections.Generic;
using System.Web;

namespace MvcApp.Controllers {

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
            return View("PersonEdit", myPerson);
        }

        [HttpPost]
        public ActionResult Index(Person person, Person myPerson) {
            return View("PersonDisplay", person);
        }

        public ViewResult Person(int id = 23) {

            // get a person record from the repository
            Person myPerson = new Person {
                        PersonId = 23,
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

            return View("PersonDisplay", myPerson);
        }

        public ViewResult Movies() {
            return View();
        }

        [HttpPost]
        public ViewResult Movies(List<string> movies) {
            return View("MoviesDisplay", movies);
        }


        public ViewResult MPerson() {

            List<Person> people = new List<Person> {
                new Person {FirstName = "Joe", LastName = "Smith"},
                new Person {FirstName = "Jane", LastName = "Doe"},
            };
            return View(people);
        }

        [HttpPost]
        public ViewResult MPerson(IDictionary<string, Person> people) {

      

            return View("MPersonDisplay", people);
        }


        public ActionResult Register() {
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

        [HttpPost]
        public ActionResult RegisterMember(FormCollection formData) {

            Person myPerson = (Person)DependencyResolver.Current.GetService(typeof(Person));


            if (TryUpdateModel(myPerson, formData)) {

                //...proceed as normal

            } else {

                //...provide UI feedback based on ModelState

            }
            return View("PersonDisplay", myPerson);
        }



        public ViewResult Upload() {
            return View();
        }

[HttpPost]
public ActionResult Upload(HttpPostedFileBase file) {


    // Save the file to disk on the server
    string filename = "myfileName"; // ... pick a filename
    file.SaveAs(filename);

    // ... or work with the data directly
    byte[] uploadedBytes = new byte[file.ContentLength];
    file.InputStream.Read(uploadedBytes, 0, file.ContentLength);
    // Now do something with uploadedBytes


    return View();
}

public ActionResult Clock(DateTime currentTime) {
    return Content("The time is " + currentTime.ToLongTimeString());
}


    }
}
