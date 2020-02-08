using Algo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class MaxDepthBinaryTreeTests
    {
        [DataTestMethod]
        [DataRow(new object[] {3,9,20,null,null,15,7}, 3)]
        public void FindMaxBinaryTreeHeightTests(object[] treeNodes, int expectedHeight)
        {
            // arrange
            var root = TreeNode.Build(treeNodes);

            // act
            int height = MaxDepthBinaryTree.MaxDepth(root);

            // assert
            Assert.AreEqual(expectedHeight, height);
        }
    }
}