namespace Algo {
    // Solution for problem: https://leetcode.com/problems/swap-nodes-in-pairs/
    // Difficulty: medium
    // Runtime: 92 ms, faster than 63.11% of C# online submissions for Swap Nodes in Pairs.
    // Memory Usage: 24.4 MB, less than 25.00% of C# online submissions for Swap Nodes in Pairs.
    public static class SwapNodesInPairs
    {
        public static ListNode SwapPairs(ListNode head) {
            var dummyHead = new ListNode(int.MinValue) { Next = head };

            ListNode prevPair = dummyHead;
            ListNode currNode = head;
            while(currNode != null) {
                ListNode nextNode = currNode.Next;

                if (nextNode != null) {
                    prevPair.Next = nextNode;
                    currNode.Next = nextNode.Next;
                    nextNode.Next = currNode;

                    prevPair = currNode;
                    currNode = currNode.Next;
                }
                else
                {
                    break; // odd numbers of elements in the LI
                }
            }

            return dummyHead.Next;
        }
    }
}