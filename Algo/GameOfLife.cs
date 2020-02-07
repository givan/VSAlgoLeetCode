using System;

namespace Algo
{
    /* Conway Game of life problem - Cloudflare coding problem
live cell with 2 or 3 neigh stays on
any dead cell with exactly 3 gets set on
all other live are made dead
dead cell stay dead
    */
    public static class GameOfLife
    {
        public static int[,] CalcTick(int[,] board)
        {
            if (board == null || board.Length == 0) { throw new ArgumentException("board must be a non empty array"); }

            int[,] result = new int[board.Length, board.Length];

            for (int rowIdx = 0; rowIdx < board.Rank; rowIdx++)
            {
                int columns = board.GetLength(rowIdx);
                for (int colIdx = 0; colIdx < columns; colIdx++)
                {
                    int cellState = DetermineState(board, rowIdx, colIdx);

                    result[rowIdx, colIdx] = cellState;
                }
            }

            return result;
        }

        private static int DetermineState(int[,] board, int rowIdx, int colIdx)
        {
            // if off and has 3 neighbors on - goes on
            // if on and has 2-3 neigh on - stays on
            // otherwise off
            int onNeighoursCount = DetermineOnNeighbors(board, rowIdx, colIdx);

            int nextState = 0;

            if (board[rowIdx, colIdx] == 1 && (onNeighoursCount == 2 || onNeighoursCount == 3))
            {
                nextState = 1;
            }
            else if (board[rowIdx, colIdx] == 0 && onNeighoursCount == 3)
            {
                nextState = 1;
            }

            return nextState;
        }

        private static int DetermineOnNeighbors(int[,] board, int rowIdx, int colIdx)
        {
            int onNeighoursCount = 0;

            onNeighoursCount += IsCellOn(board, rowIdx - 1, colIdx) ? 1 : 0; // top
            onNeighoursCount += IsCellOn(board, rowIdx + 1, colIdx) ? 1 : 0; // bottom
            onNeighoursCount += IsCellOn(board, rowIdx, colIdx - 1) ? 1 : 0; // left
            onNeighoursCount += IsCellOn(board, rowIdx, colIdx + 1) ? 1 : 0; // right
            onNeighoursCount += IsCellOn(board, rowIdx - 1, colIdx - 1) ? 1 : 0; // up left
            onNeighoursCount += IsCellOn(board, rowIdx - 1, colIdx + 1) ? 1 : 0; // up right
            onNeighoursCount += IsCellOn(board, rowIdx + 1, colIdx - 1) ? 1 : 0; // bottom left
            onNeighoursCount += IsCellOn(board, rowIdx + 1, colIdx + 1) ? 1 : 0; // bottom right

            return onNeighoursCount;
        }

        private static bool IsCellOn(int[,] board, int rowIdx, int colIdx)
        {
            return (rowIdx >= 0 && rowIdx < board.Length &&
                    colIdx >= 0 && colIdx < board.Length &&
                    board[rowIdx, colIdx] == 1);
        }
    }
}