using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class MinCostClimbingStairsTests
    {
        [DataTestMethod]
        [DataRow(new[] { 1, 7 }, 1)]
        [DataRow(new[] { 7 }, 7)]
        [DataRow(new[] { 7, 2 }, 2)]
        [DataRow(new[] { 10, 15, 20 }, 15)]
        [DataRow(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
        public void FindMinCostClimbingStairsSuccessTests(int[] stairs, int expectedMinCost)
        {
            int foundMinCost = MinCostClimbingStairs.FindMinCostClimbingStairs(stairs);

            Assert.AreEqual(expectedMinCost, foundMinCost);
        }
    }
}