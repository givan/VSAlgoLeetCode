using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/maximum-width-ramp/
    // Difficulty: Medium
    // Runtime: 1508 ms, faster than 7.69% of C# online submissions for Maximum Width Ramp.
    // Memory Usage: 34.6 MB, less than 100.00% of C# online submissions for Maximum Width Ramp.
    // The binary search solution results:
    // Runtime: 148 ms, faster than 81.48% of C# online submissions for Maximum Width Ramp.
    // Memory Usage: 35.6 MB, less than 100.00% of C# online submissions for Maximum Width Ramp.
    public static class MaximumWidthRamp
    {
        public static int MaxWidthRampWithBinarySearch(int[] nums) {
            var decreasingPairs = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(nums[0], 0)
            };

            int maxWidth = 0;

            for (int currIdx = 0; currIdx < nums.Length; currIdx++)
            {
                if (nums[currIdx] < decreasingPairs.Last().Item1) {
                    decreasingPairs.Add(new Tuple<int, int>(nums[currIdx], currIdx)); // build the list with values in decreasing order so the last element is always the smallest
                }
                else
                {
                    maxWidth = FindMaxWidthAtIndex(nums, currIdx, decreasingPairs, maxWidth);
                }
            }

            return maxWidth;
        }

        private static int FindMaxWidthAtIndex(int[] nums, int currIdx, List<Tuple<int, int>> decreasingPairs, int currentMaxWidth)
        {
            // since the decreasingPairs is strictly decreasing sequence, we can do binary search to find 
            // where does the current element fit and thus find the ramp widht for the the current node
            // compare it with the current max ramp and if it's greater, store it
            int startIdx = 0, endIdx = decreasingPairs.Count - 1;
            while (startIdx <= endIdx)
            {
                int midIdx = (startIdx + endIdx) / 2;
                if (nums[currIdx] >= decreasingPairs[midIdx].Item1)
                {
                    if (currentMaxWidth < currIdx - decreasingPairs[midIdx].Item2)
                    {
                        currentMaxWidth = currIdx - decreasingPairs[midIdx].Item2;
                    }

                    endIdx = midIdx - 1;
                }
                else
                {
                    startIdx = midIdx + 1;
                }
            }

            return currentMaxWidth;
        }

        public static int MaxWidthRamp(int[] nums)
        {
            // first create a multi-demntional array with first dimention being the values from nums
            // and second dimention being the index of teh value at the original nums array
            // we want to sort this multi dimentional array
            var sortedIndexes = nums.Select((val, i) => (val, i)).OrderBy(t => t.val).Select(t => t.i);

            int prevMin = int.MaxValue, maxWidth = 0;
            foreach (var index in sortedIndexes)
            {
                maxWidth = Math.Max(maxWidth, index - prevMin);
                prevMin = Math.Min(prevMin, index);
            }

            return maxWidth;
        }
        
        public static int FindMax(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 1) { return 0; }

            // try to see if the current array contains strictly decreasing numbers
            int maxSubsequenceEqualValues = 0;
            bool isDecreasing = IsDecreasingSequence(numbers, ref maxSubsequenceEqualValues);

            // if it's strictly decreasing but not all elements are the same
            if (isDecreasing) { return maxSubsequenceEqualValues; }

            int maxWidth = 0;

            for (int leftIdx = 0; leftIdx < numbers.Length - 1; leftIdx++)
            {
                for (int rightIdx = numbers.Length - 1; rightIdx > leftIdx + maxWidth; rightIdx--)
                {
                    if (numbers[leftIdx] <= numbers[rightIdx])
                    {
                        if (rightIdx - leftIdx > maxWidth)
                        {
                            maxWidth = rightIdx - leftIdx;
                        }

                        break; // we don't need to keep on trying for the current leftIdx since we found a max already
                    }
                }
            }

            return maxWidth;
        }

        private static bool IsDecreasingSequence(int[] numbers, ref int maxSubsequenceEqualValues)
        {
            bool isDecreasing = true;
            for (int currIdx = 0; currIdx < numbers.Length - 1; currIdx++)
            {
                if (numbers[currIdx] < numbers[currIdx + 1])
                {
                    isDecreasing = false;
                    break;
                }
                else if (numbers[currIdx] == numbers[currIdx + 1])
                {
                    // find the longest stretch with the current numbers[currIdx]
                    int startingIdx = currIdx;
                    currIdx++;
                    while (currIdx < numbers.Length && numbers[currIdx - 1] == numbers[currIdx]) { currIdx++; }
                    currIdx--; // now we're at the last elem which is equal to the num[startingIdx]

                    if (currIdx - startingIdx > maxSubsequenceEqualValues)
                    {
                        maxSubsequenceEqualValues = currIdx - startingIdx;
                    }
                }
            }

            return isDecreasing;
        }
    }
}