namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/search-in-rotated-sorted-array/
    // Difficulty: Medium
    // Runtime: 84 ms, faster than 98.60% of C# online submissions for Search in Rotated Sorted Array.
    // Memory Usage: 24.9 MB, less than 11.11% of C# online submissions for Search in Rotated Sorted Array.
    public static class SearchInRotatedSortedArray
    {
        public static int Search(int[] nums, int target)
        {
            int foundMatchedIdx = -1;

            if (nums == null || nums.Length == 0) { return foundMatchedIdx; }

            if (nums.Length == 1)
            { // special case when the array is 1 element only
                foundMatchedIdx = (nums[0] == target) ? 0 : -1;
                return foundMatchedIdx;
            }

            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = GetMid(left, right);

                if (target == nums[mid])
                {
                    foundMatchedIdx = mid;
                    break;
                }

                if (target == nums[left])
                {
                    foundMatchedIdx = left;
                    break;
                }

                if (target == nums[right])
                {
                    foundMatchedIdx = right;
                    break;
                }

                DetermineLeftAndRightFromMid(nums, target, mid, ref left, ref right);
            }

            return foundMatchedIdx;
        }

        private static void DetermineLeftAndRightFromMid(int[] nums, int target, int mid, ref int left, ref int right)
        {
            if (nums[left] < nums[mid])
            {
                if (nums[left] < target && target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if (nums[mid] < target && target < nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        private static int GetMid(int left, int right)
        {
            return (right + left) / 2;
        }
    }
}