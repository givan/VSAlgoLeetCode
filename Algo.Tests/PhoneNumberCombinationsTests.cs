using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class PhoneNumberCombinationTests
    {
        [TestMethod]
        public void OneDigitCombinationTests()
        {
            // arrange
            string digits = "2";
            var expectedWords = new List<string> { "a", "b", "c" };

            // act
            IList<string> generatedWordsList = PhoneNumberCombinations.LetterCombinations(digits);

            // assert
            CollectionAssert.AreEquivalent(expectedWords, new List<string>(generatedWordsList));
        }

        [TestMethod]
        public void TwoDigitCombinationTests()
        {
            // arrange
            string digits = "23";
            var expectedWords = new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };

            // act
            IList<string> generatedWordsList = PhoneNumberCombinations.LetterCombinations(digits);

            // assert
            CollectionAssert.AreEquivalent(expectedWords, new List<string>(generatedWordsList));
        }
    }
}