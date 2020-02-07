using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void BoardFirstTickSuccessTest()
        {
            // arrange
            var board = new int[, ] {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0 },
                { 0, 1, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            var expectedBoard = new int[, ] {
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            // act
            var resultBoard = GameOfLife.CalcTick(board);

            // assert
            Assert.AreEqual(expectedBoard.Length, resultBoard.Length);

            CollectionAssert.AreEquivalent(expectedBoard, resultBoard);

            // for (int currRowIdx = 0; currRowIdx < expectedBoard.Length; currRowIdx++)
            // for (int currColIdx = 0; currColIdx < expectedBoard.Length; currRowIdx++)
            // {
            //     Assert.AreEqual(expectedBoard[currRowIdx, currColIdx], resultBoard[currRowIdx, currColIdx]);
            // }
        }
    }
}