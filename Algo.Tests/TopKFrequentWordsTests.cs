using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    // tests for the problem: https://leetcode.com/problems/top-k-frequent-words/
    [TestClass]
    public class TopKFrequentWordsTests
    {
        [TestMethod]
        public void Top2MostFrequentWords()
        {
            // arrange
            // Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
            string[] words = new [] { "i", "love", "leetcode", "i", "love", "coding" };
            int k = 2;
            List<string> expected = new List<string> { "i", "love" };

            // act
            List<string> mostFreqWords = new List<string>(TopKFrequentWords.TopKFrequent(words, k));

            // assert
            CollectionAssert.AreEqual(expected, mostFreqWords);
        }

        [TestMethod]
        public void Top4MostFrequentWords()
        {
            // arrange
            string[] words = new[] {"the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            int k = 4;

            List<string> expectedWords = new List<string> { "the", "is", "sunny", "day" };

            // act
            IList<string> result = TopKFrequentWords.TopKFrequent(words, k);
            List<string> mostFequentWords = new List<string>(result);

            // assert
            CollectionAssert.AreEqual(expectedWords, mostFequentWords);
        }
    }
}
