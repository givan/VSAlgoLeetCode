
using System;

namespace Algos {
    // Problem: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    public static class RotateArray
    {
        /*
Given an array, rotate the array to the right by k steps, where k is non-negative.

Example 1:
Input: [1,2,3,4,5,6,7] and k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]


Example 2:
Input: [-1,-100,3,99] and k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]
             */
        public static int[] Rotate(int[] nums, int k) {
            if (nums == null || nums.Length == 0)
            {
                throw new ArgumentException("nums must be a non-empty array");
            }
            if (k < 0)
            {
                throw new ArgumentException("k must be a valid positive value denoting the number of array rotations to make");
            }

            // now if k is equal to nums.Length, then the resulting array will be the same
            // hence we want to get the remainder of k to the nums.Length to figure out how many times we need to rotate
            // the array
            k %= nums.Length;

            if (k == 0) // no changes are made so return the array as it is
            {
                return nums;
            }

            int[] buff = new int[nums.Length - k];

            // first copy all elems from beginning until k-1 index
            for(int currIdx = 0; currIdx < nums.Length - k; currIdx++) {
                buff[currIdx] = nums[currIdx];
            }

            // now shift the elements starting at index n - k to the left by k positions;
            // we have the elements up to index K stored in buff so we can recover the
            // the overriden values
            int leftIdx = 0, rightIdx = nums.Length - k;
            for(int offset = 0; offset < k; offset++)
            {
                nums[leftIdx + offset] = nums[rightIdx + offset]; 
            }

            // now finally starting from index k, copy the elements from the buffer until the end
            // we're copying the K elements from the buffer offsetting them starting the n-k index
            for (int offset = 0; offset < buff.Length; offset++)
            {
                int currIdx = k + offset;

                nums[currIdx] = buff[offset];
            }

            return nums;
        }
    }
}