using SportsStore.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests {


    [TestClass()]
    public class EmailOrderProcessorTest {

        [TestMethod]
        public void Can_Send_Email() {

            // Arrange - create and populate a cart
            Cart cart = new Cart();
            cart.AddItem(new Product { ProductID = 1, Name = "Banana", Price = 10M }, 2);
            cart.AddItem(new Product { ProductID = 2, Name = "Apple", Price = 5M }, 2);

            // Arrange - create and populate some shipping details
            ShippingDetails shipDetails = new ShippingDetails {
                Name = "Joe Smith",
                Line1 = "Apartment 4a",
                Line2 = "123 West Street",
                City = "Northtown",
                State = "GA",
                Country = "USA",
                Zip = "12345"
            };

            // Arrange - create the test-specific email settings
            EmailSettings settings = new EmailSettings {
            
                // put test specific settings here
                WriteAsFile = true
            };

            // Arrange - create the EmailOrderProcessor class
            EmailOrderProcessor proc = new EmailOrderProcessor(settings);

            // Act - process the order
            proc.ProcessOrder(cart, shipDetails);

            // NOTE - there is assert in this test

        }
    }
}
