using System;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/word-search/
    // Difficulty: Medium
    // Runtime: 136 ms, faster than 52.19% of C# online submissions for Word Search.
    // Memory Usage: 28.8 MB, less than 100.00% of C# online submissions for Word Search.
    public class WordSearch
    {
        private readonly char[][] board;

        public WordSearch(char[][] board)
        {
            if (board == null || board.Length == 0) { throw new ArgumentException("board must be a valid multi-dimentional array"); }
            this.board = board;
        }

        /// <summary>
        /// With Backtracking
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool HasWord(string word)
        {
            for (int rowIdx = 0; rowIdx < this.board.Length; rowIdx++)
            {
                for (int colIdx = 0; colIdx < this.board[rowIdx].Length; colIdx++)
                {
                    bool hasPath = CheckPathFromCurrentPosition(word, 0, rowIdx, colIdx);
                    if (hasPath) { return true; }
                }
            }

            return false;
        }

        private bool CheckPathFromCurrentPosition(string word, int currCharIdx, int currRowIdx, int currColIdx)
        {
            if (currCharIdx >= word.Length)
            {
                return true; // we found a match
            }

            // now check the indices
            if (currRowIdx < 0 || currRowIdx >= this.board.Length ||
                currColIdx < 0 || currColIdx >= this.board[currRowIdx].Length) { return false; }

            // check if the current cell matches the current word character
            if (word[currCharIdx] != this.board[currRowIdx][currColIdx]) { return false; }

            // now mark the current cell as visited (the char '#')
            this.board[currRowIdx][currColIdx] = '#';

            // now try all 4 directions from the current cell
            bool hasFound = CheckPathFromCurrentPosition(word, currCharIdx + 1, currRowIdx - 1, currColIdx); // up
            hasFound = hasFound || CheckPathFromCurrentPosition(word, currCharIdx + 1, currRowIdx + 1, currColIdx); // down
            hasFound = hasFound || CheckPathFromCurrentPosition(word, currCharIdx + 1, currRowIdx, currColIdx - 1); // left
            hasFound = hasFound || CheckPathFromCurrentPosition(word, currCharIdx + 1, currRowIdx, currColIdx + 1); // right

            // backtracking - revert the character at current pos as it was before
            this.board[currRowIdx][currColIdx] = word[currCharIdx];
            return hasFound;
        }
    }
}