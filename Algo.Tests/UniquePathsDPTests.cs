using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests {
    [TestClass]
    public class UniquePathsDPTests
    {
        [DataTestMethod]
        [DataRow(2, 3, 3)]
        [DataRow(3, 7, 28)]
        public void UniquePathsSuccessTests(int rows, int columns, int expectedPaths)
        {
            // arrange
            var uniquePathsFinder = new UniquePathsDP();

            // act
            int foundPaths = uniquePathsFinder.UniquePaths(rows, columns);

            // assert
            Assert.AreEqual(expectedPaths, foundPaths);
        }
    }
}