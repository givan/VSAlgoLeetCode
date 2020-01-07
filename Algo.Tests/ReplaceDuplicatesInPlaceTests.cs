using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class ReplaceDuplicatesInPlaceTests
    {
    [TestMethod]
        public void ReplaceDuplicatesInPlaceTest_HappyCase()
        {
            int uniqueElems = ReplaceDuplicatesInPlace.Execute(new int[] { 1, 1, 2 });
            Assert.AreEqual(2, uniqueElems, "There should have been 2 unique elements in the array");
        }

        [TestMethod]
        public void ReplaceDuplicatesWithEmptyArray() {
            int uniqueElems = ReplaceDuplicatesInPlace.Execute(new int[] {});
            Assert.AreEqual(0, uniqueElems, "There must be no unique elements in an empty array");
        }
    }
}
