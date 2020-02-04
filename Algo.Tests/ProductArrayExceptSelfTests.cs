using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class ProductArrayExceptSelfTests
    {
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
        [DataRow(new[] { 1, 2, 3}, new[] { 6, 3, 2 })]
        [DataRow(new[] { 1, 2 }, new[] { 2, 1 })]
        public void ProductArraySuccessTests(int[] input, int[] expectedOutput)
        {
            int[] result = ProductArrayExceptSelf.ProductExceptSelfNoDividion(input);

            CollectionAssert.AreEquivalent(expectedOutput, result);
        }

        [DataTestMethod]
        [DataRow(new[] { 1 })]
        [DataRow(new int[0])]
        public void ProductArrayFailureTests(int[] input)
        {
            Assert.ThrowsException<ArgumentException>(() => ProductArrayExceptSelf.ProductExceptSelfNoDividion(input));
        }

        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
        [DataRow(new[] { 1, 2, 3}, new[] { 6, 3, 2 })]
        [DataRow(new[] { 1, 2 }, new[] { 2, 1 })]
        public void ProductArraySuccessTwoArraysTests(int[] input, int[] expectedOutput)
        {
            int[] result = ProductArrayExceptSelf.ProductExceptSelfWithTwoArrays(input);

            CollectionAssert.AreEquivalent(expectedOutput, result);
        }

        [DataTestMethod]
        [DataRow(new[] { 1 })]
        [DataRow(new int[0])]
        public void ProductArrayFailureTwoArraysTests(int[] input)
        {
            Assert.ThrowsException<ArgumentException>(() => ProductArrayExceptSelf.ProductExceptSelfNoDividion(input));
        }
    }
}