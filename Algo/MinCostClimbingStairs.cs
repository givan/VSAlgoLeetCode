using System;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/min-cost-climbing-stairs/
    // Difficulty: Easy
    // Runtime: 92 ms, faster than 87.75% of C# online submissions for Min Cost Climbing Stairs.
    // Memory Usage: 26.1 MB, less than 12.50% of C# online submissions for Min Cost Climbing Stairs.
    public static class MinCostClimbingStairs
    {
        public static int FindMinCostClimbingStairs(int[] stairs) {
            if (stairs == null || stairs.Length == 0) { return 0; }

            if (stairs.Length == 1) { return stairs[0]; }

            var minCost = new int[stairs.Length]; 

            minCost[0] = stairs[0];
            minCost[1] = stairs[1]; // since the min cost to get to index 0 or 1 is 0 - we can jump directly onto them

            // at any index I, the min cost to get to it is the minCost of the cost to get to I-2 stair + the cost at I-2 stair or min cost to get to I - 1 + the cost at I-1
            for (int currStairIdx = 2; currStairIdx < stairs.Length; currStairIdx++)
            {
                minCost[currStairIdx] = stairs[currStairIdx] + Math.Min(minCost[currStairIdx - 2], minCost[currStairIdx - 1]);
            }

            return Math.Min(minCost[stairs.Length - 1], minCost[stairs.Length - 2]); // the min cost is the smaller of the last two elements
        }
    }
}