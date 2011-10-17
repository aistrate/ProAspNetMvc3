using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
            }.AsQueryable());

            AdminController controller = new AdminController(mock.Object);

            // Action
            Product[] products = ((IEnumerable<Product>)controller.Index().Model).ToArray();

            // Assert
            CollectionAssert.AreEqual(new[] { "P1", "P2", "P3" },
                                      products.Select(p => p.Name).ToArray());
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
            }.AsQueryable());

            AdminController controller = new AdminController(mock.Object);

            // Action
            Product p1 = controller.Edit(1).Model as Product,
                    p2 = controller.Edit(2).Model as Product,
                    p3 = controller.Edit(3).Model as Product;

            // Assert
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
            }.AsQueryable());

            AdminController controller = new AdminController(mock.Object);

            // Action
            Product p4 = controller.Edit(4).Model as Product;

            // Assert
            Assert.IsNull(p4);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            AdminController controller = new AdminController(mock.Object);

            Product product = new Product { Name = "Test" };

            // Action
            ActionResult result = controller.Edit(product, null);

            // Assert
            mock.Verify(m => m.SaveProduct(product), Times.Once());
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            AdminController controller = new AdminController(mock.Object);
            controller.ModelState.AddModelError("error", "error");

            Product product = new Product { Name = "Test" };

            // Action
            ActionResult result = controller.Edit(product, null);

            // Assert
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange
            Product product = new Product { ProductID = 2, Name = "Test" };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                product,
                new Product { ProductID = 3, Name = "P3" },
            }.AsQueryable());

            AdminController controller = new AdminController(mock.Object);

            // Action
            controller.Delete(product.ProductID);

            // Assert
            mock.Verify(m => m.DeleteProduct(product), Times.Once());
        }

        [TestMethod]
        public void Cannot_Delete_Invalid_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
            }.AsQueryable());

            AdminController controller = new AdminController(mock.Object);

            // Action
            controller.Delete(100);

            // Assert
            mock.Verify(m => m.DeleteProduct(It.IsAny<Product>()), Times.Never());
        }
    }
}
