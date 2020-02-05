using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class ClimbStairsTests
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(4, 5)]
        [DataRow(5, 8)]
        public void ClimbStairsSuccessTest(int stairsCount, int expectedCombinations)
        {
            int foundCombinations = ClimbStairs.CombinationsToStair(stairsCount);

            Assert.AreEqual(expectedCombinations, foundCombinations);
        }
    }
}