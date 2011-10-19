using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class MvcApplicationTest
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null,
                                                  string httpMethod = "GET")
        {
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>()))
                        .Returns<string>(p => p);

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action,
                                    object routeProperties = null, string httpMethod = "GET")
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action,
                                             object propertySet = null)
        {
            Func<object, object, bool> areEqual =
                (s1, s2) => StringComparer.InvariantCultureIgnoreCase.Compare(s1, s2) == 0;

            bool testResult = areEqual(routeResult.Values["controller"], controller) &&
                              areEqual(routeResult.Values["action"], action);

            if (testResult && propertySet != null)
                foreach (PropertyInfo propInfo in propertySet.GetType().GetProperties())
                {
                    if (!(routeResult.Values.ContainsKey(propInfo.Name) &&
                          areEqual(routeResult.Values[propInfo.Name],
                                   propInfo.GetValue(propertySet, null))))
                    {
                        testResult = false;
                        break;
                    }
                }

            return testResult;
        }

        private void TestRouteFail(string url, string httpMethod = "GET")
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        //[TestMethod]
        public void TestIncomingRoutes1()
        {
            TestRouteMatch("~/Admin/Index", "Admin", "Index");
            TestRouteMatch("~/One/Two", "One", "Two");

            TestRouteFail("~/Admin/Index/Segment");
            TestRouteFail("~/Admin");
        }

        //[TestMethod]
        public void TestIncomingRoutes2()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Customer", "Customer", "Index");
            TestRouteMatch("~/Customer/List", "Customer", "List");

            //TestRouteMatch("~/Customer/List/5", "Customer", "List", new { id = "5" });

            TestRouteFail("~/Customer/List/All");
        }

        //[TestMethod]
        public void TestIncomingRoutes3()
        {
            TestRouteMatch("~/", "Home", "Index", new { id = "DefaultId" });
            TestRouteMatch("~/Customer", "Customer", "Index", new { id = "DefaultId" });
            TestRouteMatch("~/Customer/List", "Customer", "List", new { id = "DefaultId" });
            TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });

            TestRouteFail("~/Customer/List/All/Delete");
        }

        //[TestMethod]
        public void TestIncomingRoutes4()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Customer", "Customer", "Index");
            TestRouteMatch("~/Customer/List", "Customer", "List");
            TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });

            TestRouteFail("~/Customer/List/All/Delete");
        }

        //[TestMethod]
        public void TestIncomingRoutes5()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Customer", "Customer", "Index");
            TestRouteMatch("~/Customer/List", "Customer", "List");
            TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            TestRouteMatch("~/Customer/List/All/Delete", "Customer", "List", new { id = "All", catchall = "Delete" });
            TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List", new { id = "All", catchall = "Delete/Perm" });
        }

        [TestMethod]
        public void TestIncomingRoutes6()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");

            TestRouteMatch("~/Home/About", "Home", "About");
            TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
            TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About", new { id = "MyId", catchall = "More/Segments" });

            TestRouteFail("~/Home/OtherAction");
            TestRouteFail("~/Account/Index");
            TestRouteFail("~/Account/About");
        }

        [TestMethod]
        public void TestHttpMethod()
        {
            TestRouteMatch("~/", "Home", "Index", null, "GET");
            TestRouteFail("~/", "POST");
        }

        //[TestMethod]
        public void TestStaticSegments()
        {
            TestRouteMatch("~/Shop/Index", "Home", "Index");
        }
    }
}
