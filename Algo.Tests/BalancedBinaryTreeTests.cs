using Algo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class BalancedBinaryTreeTests
    {
        [DataTestMethod]
        [DataRow(new object[] { 3, 9, 20, null, null, 15, 7 }, true)]
        [DataRow(new object[] { 1, 2, 2, 3, 3, null, null, 4, 4 }, false)]
        [DataRow(new object[] { 1, 2, 2, 3, null, null, 3, 4, null, null, 4 }, false)]
        public void IsBalancedTreeTests(object[] treeNodes, bool expectedBalanced)
        {
            // arrange
            var root = TreeNode.Build(treeNodes);

            // act
            bool isBalanced = BalancedBinaryTree.IsBalancedBinaryTree(root);

            // assert
            Assert.AreEqual(expectedBalanced, isBalanced);
        }
    }
}