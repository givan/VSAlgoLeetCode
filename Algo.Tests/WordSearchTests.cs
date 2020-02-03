using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class WordSearchTests
    {
        readonly char[][] fourByThreeBoard = {
            new [] {'A','B','C','E' },
            new [] {'S','F','C','S'},
            new [] {'A','D','E','E'}
        };

        [DataTestMethod]
        [DataRow("ASADFBCCEESE", true)]
        [DataRow("ABCCED", true)]
        [DataRow("SEE", true)]
        [DataRow("ABA", false)]
        [DataRow("ABCB", false)]
        public void FourByThreeBoardTests(string word, bool expectedMatch)
        {
            // arrange
            var wordSearch = new WordSearch(fourByThreeBoard);

            // act
            bool foundWord = wordSearch.HasWord(word);

            // assert
            Assert.AreEqual(expectedMatch, foundWord);
        }
    }
}