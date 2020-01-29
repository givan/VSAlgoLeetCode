namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/jump-game-iii/
    // Difficulty: Medium
    // Given an array of non-negative integers arr, you are initially positioned at start index of the array. When you are at index i, you can jump to i + arr[i] or i - arr[i], check if you can reach to any index with value 0.
    // Runtime: 132 ms, faster than 73.14% of C# online submissions for Jump Game III.
    // Memory Usage: 35.1 MB, less than 100.00% of C# online submissions for Jump Game III.
    public static class JumpGameV3
    {
        public static bool CanReach(int[] arr, int start)
        {
            bool canReach = false;

            if (arr == null || arr.Length == 0) { return canReach; }
            if (start < 0 || start >= arr.Length) { return canReach; }

            var visitedIndices = new int[arr.Length];

            canReach = CanReachZero(arr, start, visitedIndices);

            return canReach;
        }

        private static bool CanReachZero(int[] arr, int currentIndex, int[] visited)
        {
            if (currentIndex < 0 || currentIndex >= arr.Length) { return false; }
            if (arr[currentIndex] == 0) { return true; } // found a solution
            if (visited[currentIndex] == 1) { return false; } // this node was visited already so it's not a new solution

            visited[currentIndex] = 1;

            int rightIdx = currentIndex + arr[currentIndex];
            bool canReach = CanReachZero(arr, rightIdx, visited);
            if (!canReach) {
                int leftIdx = currentIndex - arr[currentIndex];
                canReach = CanReachZero(arr, leftIdx, visited);
            }

            return canReach;
        }
    }
}