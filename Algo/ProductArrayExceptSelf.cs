using System;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/product-of-array-except-self/
    // Difficulty: Medium
    // Runtime 0(n) and O(n) for space -> ProductExceptSelfWithTwoArrays() 
    // Runtime: 248 ms, faster than 99.15% of C# online submissions for Product of Array Except Self.
    // Memory Usage: 36.4 MB, less than 12.50% of C# online submissions for Product of Array Except Self.
    public static class ProductArrayExceptSelf
    {
        public static int[] ProductExceptSelfWithTwoArrays(int[] nums) {
            if (nums == null || nums.Length < 2)
            {
                throw new ArgumentException("nums must be an array with at least 2 positive values");
            }

            var left = new int[nums.Length];
            left[0] = 1;

            for (int currIdx = 1; currIdx < nums.Length; currIdx++)
            {
                left[currIdx] = left[currIdx - 1] * nums[currIdx - 1];
            }

            var right = new int[nums.Length];
            right[^1] = 1;

            for (int currIdx = right.Length - 2; currIdx >= 0; currIdx--)
            {
                right[currIdx] = right[currIdx + 1] * nums[currIdx + 1];
            }

            var result = new int[nums.Length];
            for (int currIdx = 0; currIdx < result.Length; currIdx++)
            {
                result[currIdx] = left[currIdx] * right[currIdx];
            }

            return result;
        }

        public static int[] ProductExceptSelfNoDividion(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                throw new ArgumentException("nums must be an array with at least 2 positive values");
            }

            var result = new int[nums.Length];
            result[0] = 1;

            for (int currIdx = 1; currIdx < nums.Length; currIdx++)
            {
                result[currIdx] = result[currIdx - 1] * nums[currIdx - 1];
            }

            int lastNum = nums[^1];
            nums[^1] = 1;
            for (int currIdx = nums.Length - 2; currIdx >= 0; currIdx--)
            {
                int tmp = nums[currIdx];
                nums[currIdx] = lastNum * nums[currIdx + 1];
                lastNum = tmp;
            }

            for (int currIdx = 0; currIdx < result.Length; currIdx++)
            {
                result[currIdx] *= nums[currIdx];
            }

            return result;
        }
    }
}