using System;
using Algo.Common;

namespace Algo
{
    public static class BalancedBinaryTree
    {
        // Solution for: https://leetcode.com/problems/balanced-binary-tree/
        // Difficulty: Easy
        // Runtime: 104 ms, faster than 49.32% of C# online submissions for Balanced Binary Tree.
        // Memory Usage: 27.4 MB, less than 14.29% of C# online submissions for Balanced Binary Tree.
        public static bool IsBalancedBinaryTree(TreeNode root)
        {
            if (root == null) { return true; }

            int leftSubtreeHeight = GetHeight(root.left);
            int rightSubtreeHeight = GetHeight(root.right);

            return (Math.Abs(leftSubtreeHeight - rightSubtreeHeight) <= 1) 
                && IsBalancedBinaryTree(root.left)
                && IsBalancedBinaryTree(root.right);
        }

        private static int GetHeight(TreeNode root)
        {
            if (root == null) { return 0; }

            int leftSubtreeHeight = GetHeight(root.left);
            int rightSubtreeHeight = GetHeight(root.right);

            return Math.Max(leftSubtreeHeight, rightSubtreeHeight) + 1;
        }
    }
}