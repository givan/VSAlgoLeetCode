using System;

namespace Algo {

    // Solution for the problem: https://leetcode.com/problems/3sum-closest/
    // Dificulty: Medium
    // Solution: O(n^3) runtime, O(1) space
    // Runtime: 120 ms, faster than 33.54% of C# online submissions for 3Sum Closest.
    // Memory Usage: 24.9 MB, less than 11.11% of C# online submissions for 3Sum Closest.
    // Solution V2 - O(n^2) runtime, O(n) space
    // Runtime: 96 ms, faster than 91.08% of C# online submissions for 3Sum Closest.
    // Memory Usage: 25.1 MB, less than 11.11% of C# online submissions for 3Sum Closest.
    public static class ThreeSumClosest
    {
        public static int Find(int[] nums, int target) {
            if (nums == null || nums.Length <= 2) { throw new ArgumentException("nums must be an array with at least 3 ints"); }

            int closestSum = nums[0] + nums[1] + nums[2];

            for (int firstIdx = 0; firstIdx < nums.Length - 2; firstIdx++)
            {
                for (int secondIdx = firstIdx + 1; secondIdx < nums.Length - 1; secondIdx++)
                {
                    for (int thirdIdx = secondIdx + 1; thirdIdx < nums.Length; thirdIdx++)
                    {
                        int currentSum = nums[firstIdx] + nums[secondIdx] + nums[thirdIdx];
                        if (currentSum == target) {
                            // we found an exact match so we can stop (we're looking for the first match)
                            return target;
                        }

                        if (Math.Abs(currentSum - target) < Math.Abs(closestSum - target)) {
                            closestSum = currentSum;
                        }
                    }
                }
            }

            return closestSum;
        }

        public static int FindV2(int[] nums, int target) {
            if (nums == null || nums.Length <= 2) { throw new ArgumentException("nums must be an array with at least 3 ints"); }

            Array.Sort(nums); // sort the nums in increasing order

            int closestSum = nums[0] + nums[1] + nums[2];

            for (int firstIdx = 0; firstIdx < nums.Length - 2; firstIdx++)
            {
                int leftIdx = firstIdx + 1;
                int rightIdx = nums.Length - 1;

                while(leftIdx < rightIdx) {
                    int currentSum = nums[firstIdx] + nums[leftIdx] + nums[rightIdx];

                    if (currentSum == target) { return target; } // we found an exact match

                    if (Math.Abs(currentSum - target) < Math.Abs(closestSum - target)) {
                        closestSum = currentSum;
                    }

                    if (currentSum < target) {
                        // since we want to increase the sum (and get closer to target),
                        // we want to move the leftIdx to the right so we get a bigger integer
                        leftIdx++;
                    }
                    else {
                        // this is the case when currentSum > target so we want to get a smaller number for next
                        // iteration. for that, we want to move the right index to the left so we get smaller number
                        rightIdx--;
                    }
                }
            }

            return closestSum;
        }
    }
}