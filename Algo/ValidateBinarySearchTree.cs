using System;
using Algo.Common;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/validate-binary-search-tree/
    // Difficulty: Medium
    // Runtime: 92 ms, faster than 95.28% of C# online submissions for Validate Binary Search Tree.
    // Memory Usage: 26.3 MB, less than 7.14% of C# online submissions for Validate Binary Search Tree.
    public static class ValidateBinarySearchTree
    {
        public static bool IsValid(TreeNode root)
        {
            return GetValidMinMaxSubtree(root, out _, out _);
        }

        static bool GetValidMinMaxSubtree(TreeNode root, out int min, out int max)
        {
            min = int.MaxValue; // any other int value will be less
            max = int.MinValue; // anny other int value will be bigger

            if (root == null) { return true; }

            bool isValid = false;

            if (GetValidMinMaxSubtree(root.Left, out int leftMin, out int leftMax) &&
                GetValidMinMaxSubtree(root.Right, out int rightMin, out int rightMax))
            {
                isValid = (root.Left == null || root.Val > leftMax) &&
                          (root.Right == null || root.Val < rightMin);

                if (isValid) {
                    min = Math.Min(leftMin, root.Val); // if it's a leaf, min and max will be the current node value
                    max = Math.Max(rightMax, root.Val);
                }
            }

            return isValid;
        }
    }
}