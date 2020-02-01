using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class SwapNodesInPairsTests
    {
        [TestMethod]
        public void SwapFourElementsLI()
        {
            // arrange
            var head = new ListNode(1)
            {
                Next = new ListNode(2)
                {
                    Next = new ListNode(3)
                    {
                        Next = new ListNode(4)
                    }
                }
            };
            var expectedHead = new ListNode(2)
            {
                Next = new ListNode(1)
                {
                    Next = new ListNode(4)
                    {
                        Next = new ListNode(3)
                    }
                }
            };

            // act
            ListNode newHead = SwapNodesInPairs.SwapPairs(head);

            // assert
            ListNode expectedNode = expectedHead, foundNode = newHead;
            while (expectedNode != null && foundNode != null)
            {
                Assert.AreEqual(expectedNode.Val, foundNode.Val);

                expectedNode = expectedNode.Next;
                foundNode = foundNode.Next;
            }
            Assert.IsNull(expectedNode); // both of them should be null
            Assert.IsNull(foundNode);
        }

        [TestMethod]
        public void Swap3ElementsLI()
        {
            // arrange
            var head = new ListNode(1)
            {
                Next = new ListNode(2)
                {
                    Next = new ListNode(3)
                }
            };
            var expectedHead = new ListNode(2)
            {
                Next = new ListNode(1)
                {
                    Next = new ListNode(3)
                }
            };

            // act
            ListNode newHead = SwapNodesInPairs.SwapPairs(head);

            // assert
            ListNode expectedNode = expectedHead, foundNode = newHead;
            while (expectedNode != null && foundNode != null)
            {
                Assert.AreEqual(expectedNode.Val, foundNode.Val);

                expectedNode = expectedNode.Next;
                foundNode = foundNode.Next;
            }
            Assert.IsNull(expectedNode); // both of them should be null
            Assert.IsNull(foundNode);
        }

        [TestMethod]
        public void Swap2ElementsLI()
        {
            // arrange
            var head = new ListNode(1)
            {
                Next = new ListNode(2)
            };
            var expectedHead = new ListNode(2)
            {
                Next = new ListNode(1)
            };

            // act
            ListNode newHead = SwapNodesInPairs.SwapPairs(head);

            // assert
            ListNode expectedNode = expectedHead, foundNode = newHead;
            while (expectedNode != null && foundNode != null)
            {
                Assert.AreEqual(expectedNode.Val, foundNode.Val);

                expectedNode = expectedNode.Next;
                foundNode = foundNode.Next;
            }
            Assert.IsNull(expectedNode); // both of them should be null
            Assert.IsNull(foundNode);
        }

        [TestMethod]
        public void Swap1ElementsLI()
        {
            // arrange
            var head = new ListNode(1);
            var expectedHead = new ListNode(1);

            // act
            ListNode newHead = SwapNodesInPairs.SwapPairs(head);

            // assert
            ListNode expectedNode = expectedHead, foundNode = newHead;
            while (expectedNode != null && foundNode != null)
            {
                Assert.AreEqual(expectedNode.Val, foundNode.Val);

                expectedNode = expectedNode.Next;
                foundNode = foundNode.Next;
            }
            Assert.IsNull(expectedNode); // both of them should be null
            Assert.IsNull(foundNode);
        }
    }
}