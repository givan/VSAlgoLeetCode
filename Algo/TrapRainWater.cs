namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/trapping-rain-water/
    // Difficulty: Hard
    // Solution: dynamic programming 
    // Complexity - O(n) runtime and O(n) space
    // Runtime: 96 ms, faster than 63.06% of C# online submissions for Trapping Rain Water.
    // Memory Usage: 25.3 MB, less than 9.09% of C# online submissions for Trapping Rain Water.
    public static class TrapRainWater
    {
        public static int Trap(int[] heights)
        {
            if (heights == null || heights.Length <= 1) { return 0; }

            // calculate the left and right max for each index from the heights
            // then for each position, find the min of the maxes from left and right 
            // the number of units current position addes will be the this min - the current position height

            int[] leftMaxHeight = new int[heights.Length];
            leftMaxHeight[0] = heights[0];
            for (int currIdx = 1; currIdx < heights.Length; currIdx++)
            {
                leftMaxHeight[currIdx] =
                    (leftMaxHeight[currIdx - 1] < heights[currIdx]) ? heights[currIdx] : leftMaxHeight[currIdx - 1];
            }

            int[] rightMaxHeight = new int[heights.Length];
            rightMaxHeight[^1] = heights[^1];
            for (int currIdx = heights.Length - 2; currIdx >= 0; currIdx--)
            {
                rightMaxHeight[currIdx] =
                    (heights[currIdx] > rightMaxHeight[currIdx + 1]) ? heights[currIdx] : rightMaxHeight[currIdx + 1];
            }

            int trappedWater = 0;
            for (int currIdx = 0; currIdx < heights.Length; currIdx++)
            {
                int currPosMinMax = (leftMaxHeight[currIdx] < rightMaxHeight[currIdx]) ? leftMaxHeight[currIdx] : rightMaxHeight[currIdx];
                if (currPosMinMax > heights[currIdx])
                {
                    trappedWater += (currPosMinMax - heights[currIdx]);
                }
            }

            return trappedWater;
        }
    }
}