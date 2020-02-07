using Algo.Common;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/same-tree/
    // Difficulty: Easy
    // Runtime: 84 ms, faster than 98.12% of C# online submissions for Same Tree.
    //Memory Usage: 24.5 MB, less than 25.00% of C# online submissions for Same Tree.
    public static class SameTree
    {
        public static bool IsSameTree(TreeNode root1, TreeNode root2) {
            if (root1 == null && root2 == null) { return true; }

            if (root1 == null || root2 == null) { return false; }

            if (root1.val != root2.val) { return false; }

            return IsSameTree(root1.left, root2.left) &&
                    IsSameTree(root1.right, root2.right); 
        }
    }
}