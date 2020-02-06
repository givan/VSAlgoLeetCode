using Algo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class SameTreeTests
    {
        [DataTestMethod]
        [DataRow(new object[] {1, 2, 3}, new object[]{ 1, 2, 3}, true)]
        [DataRow(new object[] {1, 2}, new object[]{ 1, null, 3}, false)]
        public void AreSameTreesTests(object[] tree1Nodes, object[] tree2Nodes, bool expectedAreSameTrees)
        {
            // arrange
            var root1 = TreeNode.Build(tree1Nodes);
            var root2 = TreeNode.Build(tree2Nodes);

            // act
            bool areSame = SameTree.IsSameTree(root1, root2);

            // assert
            Assert.AreEqual(expectedAreSameTrees, areSame, $"Tree1: { root1 } and Tree2: {root2} failed when compared");
        }
    }
}