using SportsStore.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SportsStore.Domain.Entities;
using System.Linq;

namespace SportsStore.UnitTests
{


    [TestClass()]
    public class EFProductRepositoryTest {


        private TestContext testContextInstance;

        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod]
        public void SaveProductTest() {
            
            // Arrange - create a repository
            EFProductRepository target = new EFProductRepository();

            // Act - change the category of the first product
            Product prod = target.Products.First();
            prod.Category = "Test";
            target.SaveProduct(prod);

                

        }
    }
}
