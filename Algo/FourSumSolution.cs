namespace Algo
{
    using System;
    using System.Collections.Generic;

    // Solution for problem: https://leetcode.com/problems/4sum/
    // Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums 
    // such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.
    // Difficulty: Medium
    // Runtime: 268 ms, faster than 84.21% of C# online submissions for 4Sum.
    // Memory Usage: 31.8 MB, less than 10.00% of C# online submissions for 4Sum.
    public static class FourSumSolution
    {
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 3) { return new List<IList<int>>(); } // simply return empty list

            // sort the numbers (since we don't need to keep their order)
            Array.Sort(nums);

            var solutions = new List<IList<int>>();

            // keep two pointers fix at any time  - first and second
            // then have two additional pointers (left and right) that we'll position always in the beginning after the second
            // then based on the sum of the four elements, we'll determine how to move the left and right
            for (int firstIdx = 0; firstIdx < nums.Length - 3; firstIdx++)
            {
                for (int secondIdx = firstIdx + 1; secondIdx < nums.Length - 2; secondIdx++)
                {
                    FindFourSumWithFirstTwoFixed(nums, target, firstIdx, secondIdx, solutions);

                    // skip duplicates for the current index
                    while (secondIdx < nums.Length - 2 && nums[secondIdx] == nums[secondIdx + 1]) { secondIdx++; }
                }

                // skip duplicates for the current index
                while (firstIdx < nums.Length - 3 && nums[firstIdx] == nums[firstIdx + 1]) { firstIdx++; }
            }

            return solutions;
        }

        private static void FindFourSumWithFirstTwoFixed(int[] nums, int target, int firstIdx, int secondIdx, List<IList<int>> solutions)
        {
            int leftIdx = secondIdx + 1;
            int rightIdx = nums.Length - 1;
            while (leftIdx < rightIdx)
            {
                int currentSum = nums[firstIdx] + nums[secondIdx] + nums[leftIdx] + nums[rightIdx];
                if (currentSum == target)
                {
                    List<int> solution =
                        new List<int> { nums[firstIdx], nums[secondIdx], nums[leftIdx], nums[rightIdx] };

                    solutions.Add(solution);

                    // move the left and right closer
                    leftIdx++;
                    rightIdx--;

                    // now skip duplicates (look the prevoius to left and next to right)
                    while (leftIdx < rightIdx && nums[leftIdx] == nums[leftIdx - 1]) { leftIdx++; }
                    while (leftIdx < rightIdx && nums[rightIdx + 1] == nums[rightIdx]) { rightIdx--; }
                }
                else if (currentSum < target)
                {
                    // we need larger values so we'll move the left idx to the right
                    leftIdx++;
                }
                else
                {
                    // this is when the currentsum is greater than target
                    // we need to get smaller value by moving right index to the left
                    rightIdx--;
                }
            }
        }
    }
}