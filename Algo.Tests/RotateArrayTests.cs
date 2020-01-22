using System;
using Algos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class RotateArrayTests
    {
        [TestMethod]
        public void RotateArray_SuccessTests()
        {
            int[] rotated = RotateArray.Rotate(new [] { 1, 2, 3, 4, 5 }, 2);
            CollectionAssert.AreEqual(new [] { 4, 5, 1, 2, 3 }, rotated);
        }

        [TestMethod]
        public void RotateArray_SuccessOneElementTests()
        {
            int[] rotated = RotateArray.Rotate(new [] { 1 }, 0);
            CollectionAssert.AreEqual(new [] { 1 }, rotated);
        }

        [TestMethod]
        public void RotateArray_Rotate0timesTest()
        {
            int[] rotated = RotateArray.Rotate(new [] { 1, 2, 3, 4, 5 }, 0);
            CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, rotated);
        }

        [TestMethod]
        public void RotateArray_Rotate1timesTest()
        {
            int[] rotated = RotateArray.Rotate(new [] { 1, 2, 3, 4, 5 }, 1);
            CollectionAssert.AreEqual(new [] { 5, 1, 2, 3, 4 }, rotated);
        }

        [TestMethod]
        public void RotateArray_RotateArrayLengthTimesTest()
        {
            int[] inputArray = new [] { 1, 2, 3, 4, 5 };
            int[] rotated = RotateArray.Rotate(inputArray, inputArray.Length); // should produce the same array
            CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, rotated);
        }

        [TestMethod]
        public void RotateArray_KTimesMore_Than_Array_Length_No_Change()
        {
            int[] rotated = RotateArray.Rotate(new [] { 1, 2 }, 5);
            CollectionAssert.AreEqual(new [] { 2, 1 }, rotated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RotateArray_NegativeKIndex()
        {
            RotateArray.Rotate(new [] { 1 }, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RotateArray_EmptyArray_Error()
        {
            RotateArray.Rotate(new int[] { }, 1);
        }
    }
}
