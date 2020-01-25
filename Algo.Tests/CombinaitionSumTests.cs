using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class CombinaitionSumTests
    {
        [TestMethod]
        public void FourCandidatesTarget7()
        {
            // arrange
            int[] candidates = new[] { 2, 3, 6, 7 };
            int target = 7;
            List<IList<int>> expectedCombinations = new List<IList<int>>() {
                new List<int>() { 2, 2, 3},
                new List<int>() { 7 }
            };

            // act
            CombinaitionsSum combinaitionSum = new CombinaitionsSum();
            IList<IList<int>> combinations = combinaitionSum.Generate(candidates, target);

            // assert
            Assert.AreEqual(expectedCombinations.Count, combinations.Count);
            for (int i = 0; i < expectedCombinations.Count; i++)
            {
                CollectionAssert.AreEquivalent(new List<int>(expectedCombinations[i]), new List<int>(combinations[i]));
            }
        }

        [TestMethod]
        public void ThreeCandidatesTarget8()
        {
            // arrange
            int[] candidates = new[] { 2, 3, 5 };
            int target = 8;
            List<IList<int>> expectedCombinations = new List<IList<int>>() {
                new List<int>() { 2, 2, 2, 2},
                new List<int>() { 2, 3, 3},
                new List<int>() { 3, 5 }
            };

            // act
            CombinaitionsSum combinaitionSum = new CombinaitionsSum();
            IList<IList<int>> combinations = combinaitionSum.Generate(candidates, target);

            // assert
            Assert.AreEqual(expectedCombinations.Count, combinations.Count);
            for (int i = 0; i < expectedCombinations.Count; i++)
            {
                CollectionAssert.AreEquivalent(new List<int>(expectedCombinations[i]), new List<int>(combinations[i]));
            }
        }
    }
}