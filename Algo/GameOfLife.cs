using System;

namespace Algo
{
    /* Conway Game of life problem - Cloudflare coding problem
live cell with 2 or 3 neigh stays on
any dead cell with exactly 3 gets set on
all other live are made dead
dead cell stay dead
    */
    public class GameOfLife
    {
        public int[,] Board { get; private set; }

        public GameOfLife(int[,] board)
        {
            if (board == null || board.Length == 0) { throw new ArgumentException("board must be a non empty array"); }

            this.Board = board;
        }
        public void CalcTick()
        {
            int rows = this.Board.GetLength(0);
            int columns = this.Board.GetLength(1);

            int[,] result = new int[rows, columns];

            for (int rowIdx = 0; rowIdx < rows; rowIdx++)
            {
                for (int colIdx = 0; colIdx < columns; colIdx++)
                {
                    int cellState = DetermineState(rowIdx, colIdx);

                    result[rowIdx, colIdx] = cellState;
                }
            }

            this.Board = result;
        }

        private int DetermineState(int rowIdx, int colIdx)
        {
            // if off and has 3 neighbors on - goes on
            // if on and has 2-3 neigh on - stays on
            // otherwise off
            int onNeighoursCount = DetermineOnNeighbors(rowIdx, colIdx);

            int nextState = 0;

            if (this.Board[rowIdx, colIdx] == 1 && (onNeighoursCount == 2 || onNeighoursCount == 3))
            {
                nextState = 1;
            }
            else if (this.Board[rowIdx, colIdx] == 0 && onNeighoursCount == 3)
            {
                nextState = 1;
            }

            return nextState;
        }

        private int DetermineOnNeighbors(int rowIdx, int colIdx)
        {
            int onNeighoursCount = 0;

            onNeighoursCount += IsCellOn(rowIdx - 1, colIdx) ? 1 : 0; // top
            onNeighoursCount += IsCellOn(rowIdx + 1, colIdx) ? 1 : 0; // bottom
            onNeighoursCount += IsCellOn(rowIdx, colIdx - 1) ? 1 : 0; // left
            onNeighoursCount += IsCellOn(rowIdx, colIdx + 1) ? 1 : 0; // right
            onNeighoursCount += IsCellOn(rowIdx - 1, colIdx - 1) ? 1 : 0; // up left
            onNeighoursCount += IsCellOn(rowIdx - 1, colIdx + 1) ? 1 : 0; // up right
            onNeighoursCount += IsCellOn(rowIdx + 1, colIdx - 1) ? 1 : 0; // bottom left
            onNeighoursCount += IsCellOn(rowIdx + 1, colIdx + 1) ? 1 : 0; // bottom right

            return onNeighoursCount;
        }

        private bool IsCellOn(int rowIdx, int colIdx)
        {
            return (rowIdx >= 0 && rowIdx < this.Board.Rank &&
                    colIdx >= 0 && colIdx < this.Board.GetLength(rowIdx) &&
                    this.Board[rowIdx, colIdx] == 1);
        }
    }
}