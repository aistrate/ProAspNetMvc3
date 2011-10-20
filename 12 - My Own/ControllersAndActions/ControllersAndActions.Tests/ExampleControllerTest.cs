using System.Text;
using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class ExampleControllerTest
    {
        [TestMethod]
        public void ViewSelectionTest()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            ViewResult result = controller.Hello();

            // Assert
            Assert.AreEqual("Hello, world", result.ViewData.Model);
        }

        [TestMethod]
        public void RedirectTest()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectResult result = controller.Redirect();

            // Assert
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void RedirectToRouteTest()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectToRouteResult result = controller.RedirectToRoute();

            // Assert
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["id"]);
        }

        [TestMethod]
        public void TextDataTest()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            ContentResult result = controller.TextData();

            // Assert
            Assert.AreEqual("text/plain", result.ContentType);
            Assert.AreEqual("This is plain text", result.Content);
            //Assert.AreEqual(Encoding.Default, result.ContentEncoding);
        }

        [TestMethod]
        public void BookTest()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            FilePathResult result = controller.Book();

            // Assert
            Assert.AreEqual("application/pdf", result.ContentType);
            Assert.AreEqual("ASP.NET MVC3.pdf", result.FileDownloadName);
            //Assert.AreEqual(@"C:\Languages\C#\MVC3\Pro ASP.NET MVC 3 Framework (Apress).pdf", result.FileName);
        }

        [TestMethod]
        public void NotFoundTest()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            HttpStatusCodeResult result = controller.NotFound();

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
