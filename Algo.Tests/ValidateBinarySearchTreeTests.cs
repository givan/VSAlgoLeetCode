using Algo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class ValidateBinarySearchTreeTests
    {
        [DataTestMethod]
        [DataRow(new object[] { 2, 1, 3 }, true)]
        [DataRow(new object[] { 10, 5, 15, null, null, 6, 20 }, false)]
        [DataRow(new object[] { 5, 1, 4, null, null, 3, 6 }, false)]
        public void ValidateBSTTests(object[] treeNodes, bool expectedIsValidBST)
        {
            // arrange
            TreeNode root = TreeNode.Build(treeNodes);

            // act
            bool isValid = ValidateBinarySearchTree.IsValid(root);

            // assert
            Assert.AreEqual(expectedIsValidBST, isValid, $"Failed validating for tree: { string.Join("-", treeNodes) }");
        }
    }
}