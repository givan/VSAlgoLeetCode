using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class WordBreakDPTests
    {
        [DataTestMethod]
        [DataRow("leetcode", new [] {"leet", "code"}, true)]
        [DataRow("applepenapple", new [] { "apple", "pen" }, true)]
        [DataRow("applepenapple", new [] { "apple", "penap" }, false)]
        [DataRow("appleappleapple", new [] { "apple"}, true)]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new [] {"a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"}, false)]
        public void MyTestMethod(string input, string[] words, bool expectedCanBeBroken)
        {
            // arrange
            // act
            bool canBeBroken = WordBreakDP.CanBeBrokenDown(input, words);

            // assert
            Assert.AreEqual(expectedCanBeBroken, canBeBroken);
        }
    }
}