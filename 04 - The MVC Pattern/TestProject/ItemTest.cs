using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMVCPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ItemTest and is intended
    ///to contain all ItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ItemTest {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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


        [TestMethod()]
        public void CanAddBid() {

            // Arrange - set up the scenario
            Item target = new Item(); 
            Member memberParam = new Member();
            Decimal amountParam = 150M;

            // Act - perform the test
            target.AddBid(memberParam, amountParam);
            
            // Assert - check the behavior
            Assert.AreEqual(1, target.Bids.Count());
            Assert.AreEqual(amountParam, target.Bids[0].BidAmount);
        }

        [TestMethod()]
        public void CannotAddLowerBid() {

            // Arrange
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;
            
            // Act & Assert
            target.AddBid(memberParam, amountParam);
            try {
                target.AddBid(memberParam, amountParam - 10);
                Assert.Fail("An exception should be thrown when adding a lower bid");
            } catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
            }
        }

        [TestMethod()]
        public void CanAddHigherBid() {

            // Arrange
            Item target = new Item();
            Member firstMember = new Member();
            Member secondMember = new Member();
            Decimal amountParam = 150M;

            // Act
            target.AddBid(firstMember, amountParam);
            target.AddBid(secondMember, amountParam + 10);
                
            // Assert
            Assert.AreEqual(2, target.Bids.Count());
            Assert.AreEqual(amountParam + 10, target.Bids[1].BidAmount);
        }
    }
}
