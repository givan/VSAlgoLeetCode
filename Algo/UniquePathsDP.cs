using System;
using System.Collections.Generic;

namespace Algo
{

    // Solution for problem: https://leetcode.com/problems/unique-paths/
    // Difficulty: Medium
    // Runtime: 36 ms, faster than 94.50% of C# online submissions for Unique Paths.
    // Memory Usage: 16.6 MB, less than 9.09% of C# online submissions for Unique Paths.
    public class UniquePathsDP
    {
        Dictionary<Tuple<int, int>, int> foundPathsFromCellToBottomRight;
        int rows;
        int columns;

        public int UniquePaths(int rows, int columns)
        {
            if (rows <= 0) { return -1; }
            if (columns <= 0) {return -1; }

            this.rows = rows;
            this.columns = columns;

            foundPathsFromCellToBottomRight = new Dictionary<Tuple<int, int>, int>(); // we'll keep all found paths in this dictionary (DP)

            int currColumn = 0, currRow = 0;
            int uniquePaths = UniquePathsFromPos(currRow, currColumn);
            return uniquePaths;
        }

        private int UniquePathsFromPos(int currRow, int currColumn)
        {
            if (currColumn == columns - 1 || currRow == rows - 1) { return 1; } // once we reach the bottom row or rightmost column there is only 1 way to go

            int pathsFromCurrentCell;

            // check if we haven't found the number of paths from the current cell before?
            var currCellTuple = new Tuple<int, int>(currRow, currColumn);
            if (foundPathsFromCellToBottomRight.ContainsKey(currCellTuple))
            {
                pathsFromCurrentCell = foundPathsFromCellToBottomRight[currCellTuple];
            }
            else
            {
                int downwardsSolutions = UniquePathsFromPos(currRow + 1, currColumn);
                int rigthwardsSolutions = UniquePathsFromPos(currRow, currColumn + 1);
                pathsFromCurrentCell = downwardsSolutions + rigthwardsSolutions;

                // DP - store the solution in the dict so we don't compute it again for the given tuple
                foundPathsFromCellToBottomRight.Add(currCellTuple, pathsFromCurrentCell);
            }

            return pathsFromCurrentCell;
        }
    }
}