using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMVCPattern.Controllers;
using TheMVCPattern.Models;

namespace TestProject {


    /// <summary>
    ///This is a test class for AdminControllerTest and is intended
    ///to contain all AdminControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdminControllerTest {


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


       // [TestMethod()]
        public void ChangeLoginNameTest() {
            // Arrange (set up a scenario)
            Member bob = new Member() { LoginName = "Bob" };
            FakeMembersRepository repositoryParam = new FakeMembersRepository();
            repositoryParam.Members.Add(bob);
            AdminController target = new AdminController(repositoryParam);
            string oldLoginParam = bob.LoginName;
            string newLoginParam = "Anastasia";

            // Act (attempt the operation)
            target.ChangeLoginName(oldLoginParam, newLoginParam);

            // Assert (verify the result)
            Assert.AreEqual(newLoginParam, bob.LoginName);
            Assert.IsTrue(repositoryParam.DidSubmitChanges);
        }

        private class FakeMembersRepository : IMembersRepository {
            public List<Member> Members = new List<Member>();
            public bool DidSubmitChanges = false;

            public void AddMember(Member member) {
                throw new NotImplementedException();
            }

            public Member FetchByLoginName(string loginName) {
                return Members.First(m => m.LoginName == loginName);
            }

            public void SubmitChanges() {
                DidSubmitChanges = true;
            }
        }
    }
}
