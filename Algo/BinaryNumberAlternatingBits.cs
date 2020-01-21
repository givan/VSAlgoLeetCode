using System;

namespace Algo
{
    // Solution for the problem: https://leetcode.com/problems/binary-number-with-alternating-bits/
    // Given a positive integer, check whether it has alternating bits: namely, if two adjacent bits will always have different values.
    public class BinaryNumberAlternatingBits
    {
        public bool HasAlternatingBits(int n)
        {
            if (n <= 0) return false;

            // conver the int into a string with the bits value at each char
            string numberBits = Convert.ToString(n, 2); // convert the int to an array using 2-based system

            // we start with the assumption that the bits are alternating until we find two consequtive bits which are equal
            bool areAlternating = true;
            for (int i = 1; i < numberBits.Length; i++)
            {
                if (numberBits[i - 1] == numberBits[i])
                {
                    areAlternating = false;
                    break;
                }
            }

            return areAlternating;
        }
    }
}
