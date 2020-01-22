using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class FindMaxProfitTests
    {
        [TestMethod]
        public void FindMaxProfit_HappyCase()
        {
            int maxProfit = FindMaxProfit.Solve(new [] { 1, 1, 2 });
            Assert.AreEqual(1, maxProfit, "The expected max profit does not match");
        }

        [TestMethod]
        public void FindMaxProfit_PricesOnlyRising()
        {
            int maxProfit = FindMaxProfit.Solve(new [] { 1, 3, 4, 5, 7 });
            Assert.AreEqual(6, maxProfit, "The expected profit is not found");
        }

        [TestMethod]
        public void FindMaxProfit_PricesFlat()
        {
            int maxProfit = FindMaxProfit.Solve(new [] { 1, 1, 1, 1, 1 });
            Assert.AreEqual(0, maxProfit, "No profit can be made when prices are flat");
        }

        [TestMethod]
        public void FindMaxProfit_PricesFlatAfterIncrease()
        {
            int maxProfit = FindMaxProfit.Solve(new [] { 1, 1, 1, 2, 2 });
            Assert.AreEqual(1, maxProfit, "Profit should be made even if the prices are flat at the end");
        }

        [TestMethod]
        public void FindMaxProfit_PricesDropping()
        {
            int maxProfit = FindMaxProfit.Solve(new [] { 6, 5, 4, 3, 2, 1 });
            Assert.AreEqual(0, maxProfit, "No profit can be made when prices are dropping");
        }
    }
}
