using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class FourSumSolutionTests
    {
        [TestMethod]
        public void FourSumSuccessTest()
        {
            // arrange
            var nums = new[] { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            string[] expectedSolutions = new[] {
                string.Join(',', new [] { -1,  0, 0, 1 }),
                string.Join(',', new [] { -2, -1, 1, 2 }),
                string.Join(',', new [] { -2,  0, 0, 2 }),
            };

            // act
            IList<IList<int>> solutions = FourSumSolution.FourSum(nums, target);

            // assert
            string[] foundSolutionsAsString = new string[solutions.Count];
            for (int currSolIdx = 0; currSolIdx < solutions.Count; currSolIdx++)
            {
                string currSolutionAsString = string.Join(',', solutions[currSolIdx]);
                foundSolutionsAsString[currSolIdx] = currSolutionAsString;
            }

            CollectionAssert.AreEquivalent(expectedSolutions, foundSolutionsAsString);
        }

        [TestMethod]
        public void FourSumSuccessZerosTest()
        {
            // arrange
            var nums = new[] { -1, -1, 0, 0, 0, 0, 1, 1 };
            int target = 0;
            string[] expectedSolutions = new[] {
                string.Join(',', new [] { -1, -1, 1, 1 }),
                string.Join(',', new [] { -1, 0, 0, 1 }),
                string.Join(',', new [] { 0, 0, 0, 0 })
            };

            // act
            IList<IList<int>> solutions = FourSumSolution.FourSum(nums, target);

            // assert
            string[] foundSolutionsAsString = new string[solutions.Count];
            for (int currSolIdx = 0; currSolIdx < solutions.Count; currSolIdx++)
            {
                string currSolutionAsString = string.Join(',', solutions[currSolIdx]);
                foundSolutionsAsString[currSolIdx] = currSolutionAsString;
            }

            CollectionAssert.AreEquivalent(expectedSolutions, foundSolutionsAsString);
        }

        [TestMethod]
        public void FourSumSuccessEightSolutionsTest()
        {
            // arrange
            var nums = new[] { -3, -2, -1, 0, 0, 1, 2, 3 };
            int target = 0;
            string[] expectedSolutions = new[] {
                string.Join(',', new [] { -3, -2, 2, 3 }),
                string.Join(',', new [] { -3, -1, 1, 3 }),
                string.Join(',', new [] { -3, 0, 0, 3 }),
                string.Join(',', new [] { -3, 0, 1, 2 }),
                string.Join(',', new [] { -2, -1, 0, 3 }),
                string.Join(',', new [] { -2, -1, 1, 2 }),
                string.Join(',', new [] { -2, 0, 0, 2 }),
                string.Join(',', new [] { -1, 0, 0, 1 }),
            };

            // act
            IList<IList<int>> solutions = FourSumSolution.FourSum(nums, target);

            // assert
            string[] foundSolutionsAsString = new string[solutions.Count];
            for (int currSolIdx = 0; currSolIdx < solutions.Count; currSolIdx++)
            {
                string currSolutionAsString = string.Join(',', solutions[currSolIdx]);
                foundSolutionsAsString[currSolIdx] = currSolutionAsString;
            }

            CollectionAssert.AreEquivalent(expectedSolutions, foundSolutionsAsString);
        }
    }
}