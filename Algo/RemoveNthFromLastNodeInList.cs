using System;

namespace Algo {

    // Solution for problem: https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    // Difficulty: Medium
    // Runtime: 80 ms, faster than 99.38% of C# online submissions for Remove Nth Node From End of List.
    // Memory Usage: 24.8 MB, less than 10.00% of C# online submissions for Remove Nth Node From End of List.
    public static class RemoveNthFromLastNodeInList
    {
        public static ListNode RemoveTheNthFromEnd(ListNode head, int n) {
            if (head == null) { return null; }
            if (n <= 0) { return head; }

            ListNode dummyHead = new ListNode(int.MinValue) { next = head }; // add a dummy head to make it easy when we need to remove the current head

            int countFromBack = RemoveTheNthFromEndBacktracking(dummyHead, n); // this recursinve method uses backtracking to 
            
            if (countFromBack < n) {
                throw new ArgumentException($"There are not {n} elements in the given linked list");
            }

            return dummyHead.next;
        }

        private static int RemoveTheNthFromEndBacktracking(ListNode currentElement, int n)
        {
            if (currentElement.next == null) { return 0; } // the last element in the list is at index 0

            // if there are more elements, call recursively to reach the end and start counting backwards
            int currentElemIdx = RemoveTheNthFromEndBacktracking(currentElement.next, n) + 1;

            if (currentElemIdx == n) {
                currentElement.next = currentElement.next.next; // we know currentElement.next is not null at this point
            }

            return currentElemIdx;
        }
    }
}