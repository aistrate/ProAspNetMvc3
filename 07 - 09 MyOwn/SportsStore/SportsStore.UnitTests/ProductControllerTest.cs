using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
                new Product { ProductID = 4, Name = "P4" },
                new Product { ProductID = 5, Name = "P5" },
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Action
            Product[] products = ((ProductsListViewModel)controller.List(null, 2).Model).Products.ToArray();

            // Assert
            Assert.IsTrue(products.Length == 2);
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
                new Product { ProductID = 4, Name = "P4" },
                new Product { ProductID = 5, Name = "P5" },
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Action
            PagingInfo pagingInfo = ((ProductsListViewModel)controller.List(null, 2).Model).PagingInfo;

            // Assert
            //Assert.AreEqual(pagingInfo, new PagingInfo { CurrentPage = 2 });
            Assert.AreEqual(pagingInfo.CurrentPage, 2, "CurrentPage");
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3, "ItemsPerPage");
            Assert.AreEqual(pagingInfo.TotalItems, 5, "TotalItems");
            Assert.AreEqual(pagingInfo.TotalPages, 2, "TotalPages");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange
            HtmlHelper htmlHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10,
            };

            Func<int, string> pageUrl = i => "Page" + i;

            // Act
            MvcHtmlString result = htmlHelper.PageLinks(pagingInfo, pageUrl);

            // Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>" +
                                               @"<a class=""selected"" href=""Page2"">2</a>" +
                                               @"<a href=""Page3"">3</a>");
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1", Category = "Cat1" },
                new Product { ProductID = 2, Name = "P2", Category = "Cat2" },
                new Product { ProductID = 3, Name = "P3", Category = "Cat1" },
                new Product { ProductID = 4, Name = "P4", Category = "Cat2" },
                new Product { ProductID = 5, Name = "P5", Category = "Cat3" },
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Action
            Product[] products = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

            // Assert
            Assert.AreEqual(products.Length, 2);
            Assert.IsTrue(products[0].Name == "P2" && products[0].Category == "Cat2");
            Assert.IsTrue(products[1].Name == "P4" && products[1].Category == "Cat2");
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1", Category = "Cat1" },
                new Product { ProductID = 2, Name = "P2", Category = "Cat2" },
                new Product { ProductID = 3, Name = "P3", Category = "Cat1" },
                new Product { ProductID = 4, Name = "P4", Category = "Cat2" },
                new Product { ProductID = 5, Name = "P5", Category = "Cat3" },
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Action
            Func<string, int> getTotalItems =
                category => ((ProductsListViewModel)controller.List(category).Model).PagingInfo.TotalItems;
            int count1 = getTotalItems("Cat1"),
                count2 = getTotalItems("Cat2"),
                count3 = getTotalItems("Cat3"),
                countAll = getTotalItems(null);

            // Assert
            Assert.AreEqual(count1, 2);
            Assert.AreEqual(count2, 2);
            Assert.AreEqual(count3, 1);
            Assert.AreEqual(countAll, 5);
        }

        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            // Arrange
            Product product = new Product
            {
                ProductID = 2,
                Name = "Test",
                ImageData = new byte[0],
                ImageMimeType = "image/png",
            };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                product,
                new Product { ProductID = 3, Name = "P3" },
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            // Action
            ActionResult result = controller.GetImage(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(product.ImageMimeType, ((FileResult)result).ContentType);
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            // Action
            ActionResult result = controller.GetImage(100);

            // Assert
            Assert.IsNull(result);
        }
    }
}
