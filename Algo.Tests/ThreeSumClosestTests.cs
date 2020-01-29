using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class ThreeSumClosestTests
    {
        [DataTestMethod]
        [DataRow(new[] { -1, 2, 1, -4 }, 1, 2)]
        [DataRow(new[] { -1, 2, 1 }, 1, 2)]
        [DataRow(new[] { -1, 2, 1, 7, 8, 9, 10 }, 1, 2)]
        [DataRow(new[] { -1, 2, 1, 7, 8, 9, 10 }, 27, 27)]
        [DataRow(new[] { -1, 2, 1, 1, 8, 9, 10 }, 3, 2)]
        [DataRow(new[] { 1, 2, 1, -1, 8, 9, 10 }, 3, 2)]
        public void ThreeSumTests(int[] nums, int target, int expectedClosestSum)
        {
            // arrange
            // act
            int foundClosestSum = ThreeSumClosest.Find(nums, target);

            // assert
            Assert.AreEqual(expectedClosestSum, foundClosestSum);
        }
    }
}