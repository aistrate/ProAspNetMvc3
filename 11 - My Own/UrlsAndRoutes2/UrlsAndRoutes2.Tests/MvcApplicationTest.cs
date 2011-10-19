using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UrlsAndRoutes2.Tests
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

        [TestMethod]
        public void TestOutgoingRoutes()
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            RequestContext context = new RequestContext(CreateHttpContext(), new RouteData());

            // Act
            string result = UrlHelper.GenerateUrl(null, "Index", "Home", null,
                                                  routes, context, true);

            // Assert
            Assert.AreEqual("/", result);
        }
    }
}
