using System;
using System.Collections.Generic;
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
            Product[] products = ((ProductsListViewModel)controller.List(2).Model).Products.ToArray();

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
            PagingInfo pagingInfo = ((ProductsListViewModel)controller.List(2).Model).PagingInfo;

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
    }
}
