using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace ProductApp.Tests
{

    [TestClass]
    public class MyPriceReducerTest
    {
        private IEnumerable<Product> products;
        private IKernel ninjectKernel;

        public MyPriceReducerTest()
        {
            ninjectKernel = new StandardKernel();
        }

        [TestInitialize]
        public void PreTestInitialize()
        {
            products = new Product[]
            {
                new Product() { Name = "Kayak", Price = 275M },
                new Product() { Name = "Lifejacket", Price = 48.95M },
                new Product() { Name = "Soccer ball", Price = 19.50M },
                new Product() { Name = "Stadium", Price = 79500M }
            };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetProducts()).Returns(products);
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            //It.IsAny<string>();
        }

        [TestMethod]
        public void All_Prices_Are_Reduced()
        {
            // Arrange
            decimal reductionAmount = 10;
            IEnumerable<decimal> prices = products.Select(e => e.Price);
            decimal[] initialPrices = prices.ToArray();
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act 
            target.ReducePrices(reductionAmount);

            // Assert    
            prices.Zip(initialPrices, (p1, p2) =>
            {
                if (p1 == p2)
                    Assert.Fail();
                return p1;
            });
        }

        [TestMethod]
        public void Correct_Total_Reduction_Amount()
        {
            // Arrange
            decimal reductionAmount = 10;
            decimal initialTotal = products.Sum(p => p.Price);
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            Assert.AreEqual(products.Sum(p => p.Price),
                            initialTotal - products.Count() * reductionAmount);
        }

        [TestMethod]
        public void Update_Method_Called_For_Each_Product()
        {
            // Arrange  
            decimal reductionAmount = 10;
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            Mock<IProductRepository> mock = Mock.Get(ninjectKernel.Get<IProductRepository>());
            foreach (Product p in products)
                mock.Verify(m => m.UpdateProduct(p), Times.Once());
        }

        [TestMethod]
        public void No_Price_Less_Than_One_Dollar()
        {
            // Arrange
            decimal reductionAmount = decimal.MaxValue;
            MyPriceReducer target = ninjectKernel.Get<MyPriceReducer>();

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            Assert.AreEqual(products.Sum(e => e.Price), products.Count());
        }
    }
}
