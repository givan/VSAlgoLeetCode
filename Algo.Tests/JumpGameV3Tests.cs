using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class JumpGameV3Tests
    {
        [DataTestMethod]
        [DataRow(new [] {4,2,3,0,3,1,2}, 3, true)]
        [DataRow(new [] {4,2,3,0,3,1,2}, 4, true)]
        [DataRow(new [] {4,2,3,0,3,1,2}, 5, true)]
        [DataRow(new [] {4,2,3,0,3,1,2}, 0, true)]
        public void JumpGameSuccessTest(int[] arr, int start, bool expectedResult)
        {
            // arrange
            // act
            bool result = JumpGameV3.CanReach(arr, start);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(new [] {3,0,2,1,2}, 2, false)]
        public void JumpGameNegativeTest(int[] arr, int start, bool expectedResult)
        {
            // arrange
            // act
            bool result = JumpGameV3.CanReach(arr, start);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}