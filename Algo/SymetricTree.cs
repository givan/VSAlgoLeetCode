using Algo.Common;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/symmetric-tree/
    // Difficulty: Easy
    public static class SymmetricTree
    {
        public static bool IsSymmetric(TreeNode root) {
            if (root == null) { return true; }

            bool isMirror = IsMirror(root.left, root.right);
            return isMirror;
        }

        private static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) { return true; }
            if (left == null || right == null) { return false; }

            bool isMirror = left.val == right.val &&
                            IsMirror(left.left, right.right) &&
                            IsMirror(left.right, right.left);
            return isMirror;
        }
    }
}