using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductApp.Tests
{

    [TestClass]
    public class MyPriceReducerTest
    {

        [TestMethod]
        public void All_Prices_Are_Changed()
        {

            // Arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            IEnumerable<decimal> prices = repo.GetProducts().Select(e => e.Price);
            decimal[] initialPrices = prices.ToArray();
            MyPriceReducer target = new MyPriceReducer(repo);

            // Act 
            target.ReducePrices(reductionAmount);

            // Assert    
            prices.Zip(initialPrices, (p1, p2) =>
            {
                if (p1 == p2)
                {
                    Assert.Fail();
                }
                return p1;
            });
        }

        [TestMethod]
        public void Correct_Total_Reduction_Amount()
        {

            // Arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            decimal initialTotal = repo.GetTotalValue();
            MyPriceReducer target = new MyPriceReducer(repo);

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            Assert.AreEqual(repo.GetTotalValue(),
                (initialTotal - (repo.GetProducts().Count() * reductionAmount)));
        }


        [TestMethod]
        public void No_Price_Less_Than_One_Dollar()
        {

            // Arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = decimal.MaxValue;
            MyPriceReducer target = new MyPriceReducer(repo);

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            foreach (Product prod in repo.GetProducts())
            {
                Assert.IsTrue(prod.Price >= 1);
            }
        }
    }
}
