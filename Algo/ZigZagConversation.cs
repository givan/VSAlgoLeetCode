using System;
using System.Collections.Generic;
using System.Text;

// Solution from problem: https://leetcode.com/problems/zigzag-conversion/
namespace Algo
{
    public class ZigZag
    {
        public string Convert(string s, int numRows)
        {
            if (s == null || s.Length == 0)
            {
                return s;
            }

            if (numRows <= 0)
            {
                return "";
            }

            if (numRows == 1 || s.Length <= numRows)
            {
                // no changes are made and we'll simply return the string as it is
                return s;
            }

            // init the dictionary with empty lists as each row is 0-based and is the key in the dictionary
            // the value is the list of characters found left to right; we always will append to the end
            Dictionary<int, List<char>> rowNumberToCharList = new Dictionary<int, List<char>>();
            for (int i = 0; i < numRows; i++)
            {
                rowNumberToCharList.Add(i, new List<char>());
            }

            // we want to encode a whole element starting from index 0 up to 2 * numRows - 2 because
            // we see there is cyclic distribution of the letters beyond these rows
            // we will have a map with key the row number (0-based) and a list of characters for the current row
            // within that batch of 2 * numRows - 2 characters, we have the first numRows elements which match directly into 0 - numRows-1 rows
            int cyclicDivisor = 2 * numRows - 2;
            for (int currIdx = 0; currIdx < s.Length; currIdx++)
            {
                int currentIdxRemainder = currIdx % cyclicDivisor;

                List<char> currentRowChars;

                // now we will use the numRows to determine if the correct row where the current index should map to
                // if currentIdxRemainder is less than numRows, then we just add it to the row as identified 
                // if the currentIdxRemainder is equal to numRows then we simply need to put it into row with index numRows - 1
                // if the currentIdxRemainder is numRows + 1 (so basically remainder of 1 when modulus numRows) we need to numRows (- 1) (-1)
                if (currentIdxRemainder < numRows)
                {
                    currentRowChars = rowNumberToCharList[currentIdxRemainder];
                }
                else
                {
                    int divisor = currentIdxRemainder / numRows; // this should be at most 1 since currentIdxRemainder is less than 2 * numRows - 2
                    int remainder = currentIdxRemainder % numRows;// this will be between 0 up to numRows - 2 (since cyclincDivisor is 2 * numRows - 2)

                    int currentRowIdx = numRows - 1 - divisor - remainder;
                    currentRowChars = rowNumberToCharList[currentRowIdx];
                }

                currentRowChars.Add(s[currIdx]); // just add the current char to the end of the identified row
            }

            // at this point simply iterate the dictionary starting from key 0 up to numRows - 1 and append the chars at each row
            StringBuilder sbEncodedString = new StringBuilder();
            for (int currentRow = 0; currentRow < numRows; currentRow++)
            {
                List<char> currentRowChars = rowNumberToCharList[currentRow];
                sbEncodedString.AppendJoin("", currentRowChars);
            }

            return sbEncodedString.ToString();
        }
    }
}