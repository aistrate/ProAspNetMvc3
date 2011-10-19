using URLsAndRoutes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Routing;
using Moq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace URLsAndRoutes.Tests
{


    [TestClass()]
    public class MvcApplicationTest {


        private TestContext testContextInstance;

        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }


private HttpContextBase CreateHttpContext(string targetUrl = null, 
                                          string httpMethod = "GET") {
    // create the mock request 
    Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
    mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
    mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

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

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, 
            string action, object propertySet = null) {

            Func<object, object, bool> valCompare = (v1, v2) => {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller)
                &&  valCompare(routeResult.Values["action"], action);
                
            if (propertySet != null) {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo) {
                    if (!(routeResult.Values.ContainsKey(pi.Name) 
                        && valCompare(routeResult.Values[pi.Name], 
                            pi.GetValue(propertySet, null)))) {
                        
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

private void TestRouteMatch(string url, string controller, string action, object 
    routeProperties = null, string httpMethod = "GET") {

    // Arrange
    RouteCollection routes = new RouteCollection();
    MvcApplication.RegisterRoutes(routes);
    // Act - process the route
    RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));
    // Assert
    Assert.IsNotNull(result);
    Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
}

        private void TestRouteFail(string url, string httpMethod = "GET") {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));
            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }


[TestMethod]
public void TestOutgoingRoutes() {

    // Arrange
    RouteCollection routes = new RouteCollection();
    MvcApplication.RegisterRoutes(routes);

    RequestContext context = new RequestContext(CreateHttpContext(), new RouteData());

    // Act - generate the URL
    string result = UrlHelper.GenerateUrl(null, "Index", "Home", null, 
        routes, context, true);

    // Assert
    Assert.AreEqual("/", result);
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
        public void TestIncomingRoutes() {

            //TestRouteMatch("~/", "Home", "Index", null, "GET");
            //TestRouteFail("~/", "POST");


            //TestRouteMatch("~/", "Home", "Index");
            //TestRouteMatch("~/Home", "Home", "Index");
            //TestRouteMatch("~/Home/Index", "Home", "Index");


            //TestRouteMatch("~/Home/About", "Home", "About");
            //TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
            //TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About",
            //    new {
            //        id = "MyId",
            //        catchall = "More/Segments"
            //    });

            //TestRouteFail("~/Home/OtherAction");
            //TestRouteFail("~/Account/Index");
            //TestRouteFail("~/Account/About");


            //TestRouteMatch("~/", "Home", "Index");
            //TestRouteMatch("~/Customer", "Customer", "Index");
            //TestRouteMatch("~/Customer/List", "Customer", "List");
            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            //TestRouteMatch("~/Customer/List/All/Delete", "Customer", "List",
            //    new { id = "All", catchall = "Delete" });
            //TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List",
            //    new { id = "All", catchall = "Delete/Perm" });


            //TestRouteMatch("~/", "Home", "Index");
            //TestRouteMatch("~/Customer", "Customer", "index");
            //TestRouteMatch("~/Customer/List", "Customer", "List");
            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            //TestRouteFail("~/Customer/List/All/Delete");


            //TestRouteMatch("~/", "Home", "Index", new { id = "DefaultId" });
            //TestRouteMatch("~/Customer", "Customer", "index", new { id = "DefaultId" });
            //TestRouteMatch("~/Customer/List", "Customer", "List", new { id = "DefaultId" });
            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            //TestRouteFail("~/Customer/List/All/Delete");



            //TestRouteMatch("~/Shop/Index", "Home", "Index");

            //TestRouteMatch("~/", "Home", "Index");
            //TestRouteMatch("~/Customer", "Customer", "Index");
            //TestRouteMatch("~/Customer/List", "Customer", "List");
            //TestRouteFail("~/Customer/List/All"); 


            //// check for the URL that we hope to receive
            //TestRouteMatch("~/Admin/Index", "Admin", "Index");
            //// check that the values are being obtained from the segments
            //TestRouteMatch("~/One/Two", "One", "Two");

            //// ensure that too many of too few segments fails to match
            //TestRouteFail("~/Admin/Index/Segment");
            //TestRouteFail("~/Admin");
        }
    }
}
