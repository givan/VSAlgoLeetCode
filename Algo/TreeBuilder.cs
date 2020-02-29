using System;
using Algo.Common;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
    // Difficulty: Medium
    // Runtime: 108 ms, faster than 55.56% of C# online submissions for Construct Binary Tree from Inorder and Postorder Traversal.
    // Memory Usage: 27.2 MB, less than 50.00% of C# online submissions for Construct Binary Tree from Inorder and Postorder Traversal.
    public static class TreeBuilder
    {
        public static TreeNode Build(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0 || postorder == null || postorder.Length == 0 || inorder.Length != postorder.Length) {
                return null;
            }

            TreeNode root = BuildFromInOrderAndPostOrderSubArray(inorder, postorder, 0, 0, inorder.Length);
            return root;
        }

        private static TreeNode BuildFromInOrderAndPostOrderSubArray(int[] inorder, int[] postorder, int inOrderIdx, int postOrderIdx, int nodeCount)
        {
            // the current root element is the last element in the post order array
            if (nodeCount == 1)
            {
                TreeNode leaf = new TreeNode(postorder[postOrderIdx]);
                return leaf;
            }

            int postOrderRootIdx = postOrderIdx + nodeCount - 1;
            int rootVal = postorder[postOrderRootIdx];
            TreeNode root = new TreeNode(rootVal); // the post order array's last element is the root of the current tree

            int rootValIdx = Array.FindIndex<int>(inorder, (val) => val == rootVal);

            int leftTreeNodeCount = rootValIdx - inOrderIdx;
            if (leftTreeNodeCount > 0)
            {
                TreeNode leftTreeRoot = BuildFromInOrderAndPostOrderSubArray(inorder, postorder, inOrderIdx, postOrderIdx, leftTreeNodeCount);
                root.left = leftTreeRoot;
            }

            int rightTreeNodeCount = inOrderIdx + nodeCount - rootValIdx - 1;
            if (rightTreeNodeCount > 0)
            {
                TreeNode rightTreeRoot = BuildFromInOrderAndPostOrderSubArray(inorder, postorder, rootValIdx + 1, postOrderRootIdx - rightTreeNodeCount, rightTreeNodeCount);
                root.right = rightTreeRoot;
            }

            return root;
        }
    }
}