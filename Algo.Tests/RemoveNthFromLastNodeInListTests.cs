using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class RemoveNthFromLastNodeInListTests {
        [TestMethod]
        public void RemoveHeadTest() {
            // arrange
            ListNode singleElem = new ListNode(1);

            // act
            ListNode newHead = RemoveNthFromLastNodeInList.RemoveTheNthFromEnd(singleElem, 1);

            // assert
            Assert.IsNull(newHead); // make sure the list is now empty
        }

        [TestMethod]
        public void RemoveSecondFromLastTest() {
            // arrange
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            // act
            int secondFromLast = 2; // second from last is 4
            int expectedNodeValueToRemove = 4;

            ListNode newHead = RemoveNthFromLastNodeInList.RemoveTheNthFromEnd(head, secondFromLast);

            // assert
            Assert.AreEqual(head, newHead);

            ListNode currElem = newHead;
            while(currElem != null) {
                Assert.AreNotEqual(expectedNodeValueToRemove, currElem.val);
                currElem = currElem.next;
            }
        }

        [TestMethod]
        public void NoChangesWhenNIsZero() {
            // arrange
            var head = new ListNode(1);

            // act
            int zeroIdx = 0;
            ListNode newHead = RemoveNthFromLastNodeInList.RemoveTheNthFromEnd(head, zeroIdx);

            // assert
            Assert.IsNotNull(newHead);
            Assert.AreEqual(head, newHead);
            Assert.AreEqual(1, newHead.val);
        }

        [TestMethod]
        public void NoChangesWhenNIsLargerThanLISize() {
            // arrange
            var head = new ListNode(1);

            // act + assert
            int twoElems = 2; // this list has only 1 element and we want to remove the 2nd from the last (which doesn't exist)

            Assert.ThrowsException<ArgumentException>(
                () => RemoveNthFromLastNodeInList.RemoveTheNthFromEnd(head, twoElems)
            );
        }
    }
}