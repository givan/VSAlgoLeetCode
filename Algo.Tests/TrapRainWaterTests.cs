using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class TrapRainWaterTests
    {
        [DataTestMethod]
        [DataRow(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [DataRow(new[] {3, 2, 1}, 0)]
        [DataRow(new[] {1, 2, 3}, 0)]
        [DataRow(new[] {1, 2, 3}, 0)]
        [DataRow(new[] {3}, 0)]
        public void TrapWaterSuccessTest(int[] heights, int expectedWater)
        {
            // arrange
            // act
            int trappedWater = TrapRainWater.Trap(heights);

            // assert
            Assert.AreEqual(expectedWater, trappedWater);
        }
    }
}