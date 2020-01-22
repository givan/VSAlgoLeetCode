using System;
using System.Collections.Generic;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/reverse-integer/
    // Given a 32-bit signed integer, reverse digits of an integer.
    // Easy
    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            if (x == 0)
            {
                return x;
            }

            // if negative, keep a flag it's negative that will be applied at the end; now simply make it positive
            // at this point we know we have a positive number (and a flag that denotes if the input was a negative value)
            bool negative = false;
            if (x < 0)
            {
                negative = true;
                x = -x;
            }

            // while the current number is greater than 10
            // modulus of the current number to 10 to determine the last digit
            // push the found digit to the linked list to the end; this way, we'll be reversing the digits
            // divide the current number to 10 and assign it to x
            List<int> parsedDigits = new List<int>();
            while (x != 0)
            {
                int currentDigit = x % 10;
                parsedDigits.Add(currentDigit);
                x /= 10;
            }

            // now iterate over the LI and multiply the current digit based on its index from the LI
            int reversedNum = 0;
            while (parsedDigits.Count > 0)
            {
                try
                {
                    checked
                    {
                        int currentNumber = parsedDigits[0] * (int)(Math.Pow(10, parsedDigits.Count - 1));
                        reversedNum += currentNumber;
                    }

                    parsedDigits.RemoveAt(0); // remove the first digit which we already added
                }
                catch (OverflowException)
                {
                    reversedNum = 0; // if overflow happens, the return value is 0
                    break;
                }

            }

            return (negative) ? -reversedNum : reversedNum;
        }
    }
}