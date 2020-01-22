using System;
using System.Collections.Generic;

namespace Algo
{
    public static class ReplaceDuplicatesInPlace
    {
        // Problem: https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        public static int Execute(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int lastUniqueIdx = 0;
            int currentIdx = lastUniqueIdx + 1;

            while (currentIdx < nums.Length)
            {
                if (nums[currentIdx] == nums[lastUniqueIdx])
                {
                    currentIdx++; // only advance the current index until we find
                    // a new item that is different from the current last uqnie element
                    // or we reach the end of the array
                }
                else
                {
                    // at this point we found a different element so we need to advance
                    // both current and last uqnie element after we copy it over
                    lastUniqueIdx++;
                    nums[lastUniqueIdx] = nums[currentIdx];
                    currentIdx++;
                }
            }

            return lastUniqueIdx + 1;
        }
    }
}
