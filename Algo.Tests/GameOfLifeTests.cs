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
            var game = new GameOfLife(board);
            game.CalcTick();
            var resultBoard = game.Board;

            // assert
            Assert.AreEqual(expectedBoard.Length, resultBoard.Length);
            Assert.AreEqual(expectedBoard.Rank, resultBoard.Rank);

            for (int rowIdx = 0; rowIdx < resultBoard.GetLength(0); rowIdx++)
            {
                for (int colIdx = 0; colIdx < resultBoard.GetLength(1); colIdx++)
                {
                    Assert.AreEqual(expectedBoard[rowIdx, colIdx], resultBoard[rowIdx, colIdx]);
                }
            }
        }
    }
}