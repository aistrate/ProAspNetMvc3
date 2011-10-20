using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using System.Web;

namespace ControllersAndActions.Tests
{


    [TestClass()]
    public class ExampleControllerTest {


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
public void ContentTest() {

    // Arrange - create the controller
    ExampleController target = new ExampleController(); 

    // Act - call the action method
    ContentResult result = target.Index();
            
    // Assert - check the result
    Assert.AreEqual("text/plain", result.ContentType);
    Assert.AreEqual("This is plain text", result.Content);
}


private HttpContextBase CreateHttpContext(string targetUrl = null) {
    // create the mock request 
    Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
    mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);

    // create the mock response
    Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
    mockResponse.Setup(m => m.ApplyAppPathModifier(
        It.IsAny<string>())).Returns<string>(s => s);

    // create the mock context, using the request and response
    Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
    mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
    mockContext.Setup(m => m.Response).Returns(mockResponse.Object);
    // return the mocked context
    return mockContext.Object;
}

[TestMethod]
public void RedirectValueTest() {

    // Arrange - create the controller
    ExampleController target = new ExampleController();
    
    // Act - call the action method
    RedirectToRouteResult result = target.Redirect();
    
    // Assert - check the result
    Assert.IsFalse(result.Permanent);
    Assert.AreEqual("Example", result.RouteValues["controller"]);
    Assert.AreEqual("Index", result.RouteValues["action"]);
    Assert.AreEqual("MyID", result.RouteValues["ID"]);
}


[TestMethod]
public void RedirectURLTest() {

    // Arrange - create the controller
    ExampleController target = new ExampleController();
    // Arrange - populate a route collection
    RouteCollection routes = new RouteCollection();
    MvcApplication.RegisterRoutes(routes);
    // Arrange - create a request context
    RequestContext context = new RequestContext(CreateHttpContext(), new RouteData());

    // Act - call the action method
    RedirectToRouteResult result = target.Redirect();
    // Act - generate the URL
    string resultURL = UrlHelper.GenerateUrl(result.RouteName, null , null , 
        result.RouteValues, routes, context, true);

    // Assert - check the result
    Assert.IsFalse(result.Permanent);
    Assert.AreEqual("/Example/Index/MyID", resultURL);
}


[TestMethod]
public void FileResultTest() {

    // Arrange - create the controller
    ExampleController target = new ExampleController();

    // Act - call the action method
    FileResult result = target.AnnualReport();

    // Assert - check the result
    Assert.AreEqual(@"c:\AnnualReport.pdf", ((FilePathResult)result).FileName);
    Assert.AreEqual("application/pdf", result.ContentType);
    Assert.AreEqual("AnnualReport2011.pdf", result.FileDownloadName);
}

[TestMethod]
public void StatusCodeResultTest() {

    // Arrange - create the controller
    ExampleController target = new ExampleController();

    // Act - call the action method
    HttpStatusCodeResult result = target.StatusCode();

    // Assert - check the result
    Assert.AreEqual(404, result.StatusCode);
}

    }
}
