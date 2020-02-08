using System;
using Algo.Common;

namespace Algo
{
    public static class MaxDepthBinaryTree
    {
        // Solution for problem: https://leetcode.com/problems/maximum-depth-of-binary-tree
        // Difficulty: Easy
        // Runtime: 88 ms, faster than 97.48% of C# online submissions for Maximum Depth of Binary Tree.
        // Memory Usage: 25.4 MB, less than 5.88% of C# online submissions for Maximum Depth of Binary Tree.
        public static int MaxDepth(TreeNode root) {
            if (root == null) { return 0; }

            int leftHeight = MaxDepth(root.left);
            int rightHeight = MaxDepth(root.right);

            return Math.Max(leftHeight, rightHeight) + 1; // add 1 for the current level
        }
    }
}