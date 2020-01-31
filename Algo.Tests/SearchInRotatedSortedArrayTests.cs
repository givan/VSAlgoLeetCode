using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class SearchInRotatedSortedArrayTests
    {
        [DataTestMethod]
        [DataRow(new[] { 5, 6, 7, 0, 1, 2, 3, 4 }, 7, 2)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1 }, 0, 4)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1 }, 1, 5)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1 }, 7, 3)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1, 2 }, 7, 3)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
        [DataRow(new[] { 1 }, 3, -1)]
        [DataRow(new[] { 0, 1 }, 0, 0)]
        [DataRow(new[] { 0, 1 }, 2, -1)]
        [DataRow(new[] { 0, 1 }, -1, -1)]
        [DataRow(new[] { 0, 1 }, 1, 1)]
        [DataRow(new[] { 1 }, 1, 0)]
        public void SearchInRotatedArraySuccessTest(int[] nums, int target, int expectedFoundIdx)
        {
            // arrange
            // act
            int foundIdx = SearchInRotatedSortedArray.Search(nums, target);

            // assert
            Assert.AreEqual(
                expectedFoundIdx, foundIdx, 
                $"Couldn't find { target } at index { expectedFoundIdx } in array: { String.Join(" ", nums) }"
            );
        }
    }
}