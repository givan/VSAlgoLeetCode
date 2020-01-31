using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class MaximumWidthRampTests
    {
        [DataTestMethod]
        [DataRow(new[] { 6, 0, 8, 2, 1, 5 }, 4)]
        [DataRow(new[] { 2, 2, 1 }, 1)]
        [DataRow(new[] { 2, 2, 2 }, 2)]
        public void FindMaxWidthRampSuccessTest(int[] nums, int expectedMax)
        {
            // arrange
            // act
            int actualMax = MaximumWidthRamp.FindMax(nums);

            // assert
            Assert.AreEqual(expectedMax, actualMax);
        }

        [DataTestMethod]
        [DataRow(new[] { 3, 2, 1, 0 })]
        public void FindMaxWidthRampNegativeTest(int[] nums)
        {
            // arrange
            // act
            int actualMax = MaximumWidthRamp.FindMax(nums);

            // assert
            Assert.AreEqual(0, actualMax);
        }

        [DataTestMethod]
        [DataRow(new[] { 6, 0, 8, 2, 1, 5 }, 4)]
        [DataRow(new[] { 2, 2, 1 }, 1)]
        [DataRow(new[] { 2, 2, 2 }, 2)]
        public void FindMaxWidthRampSuccessTestV2(int[] nums, int expectedMax)
        {
            // arrange
            // act
            int actualMax = MaximumWidthRamp.MaxWidthRamp(nums);

            // assert
            Assert.AreEqual(expectedMax, actualMax);
        }

        [DataTestMethod]
        [DataRow(new[] { 3, 2, 1, 0 })]
        public void FindMaxWidthRampNegativeTestV2(int[] nums)
        {
            // arrange
            // act
            int actualMax = MaximumWidthRamp.MaxWidthRamp(nums);

            // assert
            Assert.AreEqual(0, actualMax);
        }

                [DataTestMethod]
        [DataRow(new[] { 6, 0, 8, 2, 1, 5 }, 4)]
        [DataRow(new[] { 2, 2, 1 }, 1)]
        [DataRow(new[] { 2, 2, 2 }, 2)]
        public void FindMaxWidthRampSuccessBinarySearchTest(int[] nums, int expectedMax)
        {
            // arrange
            // act
            int actualMax = MaximumWidthRamp.MaxWidthRampWithBinarySearch(nums);

            // assert
            Assert.AreEqual(expectedMax, actualMax);
        }
    }
}