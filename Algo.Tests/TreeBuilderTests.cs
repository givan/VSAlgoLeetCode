using Algo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class TreeBuilderTests
    {
        [DataTestMethod]
        [DataRow(new[] { 9, 3, 15, 20, 7 }, new[] { 9, 15, 7, 20, 3 }, "3, 9, 20, 15, 7")]
        [DataRow(new[] { 9 }, new[] { 9 }, "9")]
        [DataRow(new[] { 8, 9, 10 }, new[] { 8, 10, 9 }, "9, 8, 10")]
        [DataRow(new[] { 4, 2, 5, 1, 3 }, new[] { 4, 5, 2, 3, 1 }, "1, 2, 4, 5, 3")]
        [DataRow(new int [] {  }, new int[] {  }, "")]
        public void InOrderPostOrderSuccessTest(int[] inorder, int[] postorder, string expectedPreOrderTree)
        {
            // arrange
            // act
            TreeNode root = TreeBuilder.Build(inorder, postorder);
            var actualPreOrderTree = (root != null) ? root.ToString(): "";

            // assert
            Assert.AreEqual(expectedPreOrderTree, actualPreOrderTree);
        }
    }
}