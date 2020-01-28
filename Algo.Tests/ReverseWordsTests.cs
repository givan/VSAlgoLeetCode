using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class ReverseWordsTests
    {
        [DataTestMethod]
        [DataRow("the sky is blue", "blue is sky the")]
        [DataRow("  hello world!  ", "world! hello")]
        [DataRow("", "")]
        [DataRow("       ", "")]
        public void ReverseWordsPositiveTests(string input, string expectedReversedWords) {
            // arrange
            // act
            string reversedWords = ReverseWords.Solution(input);

            // assert
            Assert.AreEqual(expectedReversedWords, reversedWords);
        }
    }
}