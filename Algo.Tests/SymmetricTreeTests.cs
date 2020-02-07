using Algo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class SymmetricTreeTests
    {
        [DataTestMethod]
        [DataRow(new object[] { 1 }, true)]
        [DataRow(new object[] { 1, 2, 2 }, true)]
        [DataRow(new object[] { 1, 2, 2, null, 3, 3, null }, true)]
        [DataRow(new object[] { 1, 2, 2, 3, null, 3, null }, false)]
        [DataRow(new object[] { 1, 2, 2, null, null, 3, null }, false)]
        [DataRow(new object[] { 1, 2, 2, 3, 4, 4, 3 }, true)]
        [DataRow(new object[] { 1, 2, 2, null, 3, null, 3 }, false)]
        public void CheckSymmetricTreeTest(object[] treeNodes, bool expectedSymmetricTree)
        {
            // arrange
            TreeNode root = TreeNode.Build(treeNodes);

            // act
            bool isSymmetric = SymmetricTree.IsSymmetric(root);

            // assert
            Assert.AreEqual(expectedSymmetricTree, isSymmetric);
        }
    }
}