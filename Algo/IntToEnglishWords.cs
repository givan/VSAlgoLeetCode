namespace Algo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    // Solution for problem: https://leetcode.com/problems/integer-to-english-words/
    // Difficulty: Hard
    // Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 2^31 - 1.
    public static class IntegerToEnglishWords
    {
        private static readonly int BILLION = 1000000000;
        private static readonly int MILLION = 1000000;
        private static readonly int THOUSAND = 1000;
        private static readonly int HUNDRED = 100;
        private static readonly int TEN = 10;

        private static readonly int ONE = 1;

        private static readonly Dictionary<int, string> NUMBER_TO_ENGLISH_WORD = new Dictionary<int, string>
        {
            [1] = "One",
            [2] = "Two",
            [3] = "Three",
            [4] = "Four", // 1,000 - 99999
            [5] = "Five", // 100,000 - 999999
            [6] = "Six", // 1000,000 - 999,000,
            [7] = "Seven", // 
            [8] = "Eight",
            [9] = "Nine",
            [TEN] = "Ten",
            [11] = "Eleven",
            [12] = "Twelve",
            [13] = "Thirteen",
            [14] = "Fourteen",
            [15] = "Fifteen",
            [16] = "Sixteen",
            [17] = "Seventeen",
            [18] = "Eighteen",
            [19] = "Nineteen",
            [20] = "Twenty",
            [30] = "Thirty",
            [40] = "Forty",
            [50] = "Fifty",
            [60] = "Sixty",
            [70] = "Seventy",
            [80] = "Eighty",
            [90] = "Ninety",
            [HUNDRED] = "Hundred",
            [THOUSAND] = "Thousand",
            [MILLION] = "Million",
            [BILLION] = "Billion"
        };

        public static string NumberToWords(int num)
        {
            if (num < 0) { throw new ArgumentException("num must be non negative number"); }

            if (num == 0) { return "Zero"; }

            var sbNumber = new StringBuilder();

            // extract billions (if any); if there billions, substract them from the number and add to the words representing the number to the buffer
            if (num >= BILLION)
            {
                num = ExtractNumberFromBase(num, BILLION, sbNumber);
            }

            // extract millions (if any); if there are millions, substract them from the number and add the words prepresenting the number to the buffer
            // this will leverage the the extract functions for thousands, hundreds, tens and ones
            if (num >= MILLION)
            {
                sbNumber.Append(" ");
                num = ExtractNumberFromBase(num, MILLION, sbNumber);
            }

            // extract thousands (if any)
            // this will leverage the ones and tens since thousands can ben between 1 and 999
            if (num >= THOUSAND)
            {
                sbNumber.Append(" ");
                num = ExtractNumberFromBase(num, THOUSAND, sbNumber);
            }

            // extract hundreds (if any)
            if (num >= HUNDRED)
            {
                sbNumber.Append(" ");
                num = ExtractHundreds(num, sbNumber);
            }

            // extract tens (if any)
            if (num >= TEN)
            {
                sbNumber.Append(" ");
                num = ExtractTens(num, sbNumber);
            }

            // extract ones (if any)
            if (num >= ONE)
            {
                sbNumber.Append(" ");
                ExtractOnes(num, sbNumber);
            }

            return sbNumber.ToString().Trim(); // remove any trailing whitespaces
        }

        private static void ExtractOnes(int num, StringBuilder sbNumber)
        {
            string ones = NUMBER_TO_ENGLISH_WORD[num];
            sbNumber.Append(ones);
        }

        private static int ExtractTens(int num, StringBuilder sbNumber)
        {
            int remainder;
            string tensWord;

            // if the number is contained in the map, we have a direct match
            if (NUMBER_TO_ENGLISH_WORD.ContainsKey(num))
            {
                tensWord = NUMBER_TO_ENGLISH_WORD[num];
                remainder = 0; // we have a direct match
            }
            else
            {
                // remove the last digit in this 2 digit number
                int tens = (num / TEN) * TEN;

                tensWord = $"{NUMBER_TO_ENGLISH_WORD[tens]}";

                // now just remove the last digit
                remainder = num % TEN;
            }

            sbNumber.Append(tensWord);

            return remainder;
        }

        private static int ExtractHundreds(int num, StringBuilder sbNumber)
        {
            var sbHundreds = new StringBuilder();

            int hundreds = num / HUNDRED; // this should be a digit between 1 and 9 hence we're treating the number as 1 digit
            ExtractOnes(hundreds, sbHundreds);

            string hundredsWords = $" { NUMBER_TO_ENGLISH_WORD[HUNDRED] }";
            sbHundreds.Append(hundredsWords);
            sbNumber.Append(sbHundreds.ToString());

            int remainder = num % HUNDRED;
            return remainder;
        }

        /// <summary>
        /// Extracts a number from the given num using the base specified. It adds the parsed number to the string and removes from the original number what was parsed
        /// </summary>
        /// <param name="num">The number to parse</param>
        /// <param name="baseNumber">The base number which we want to parse (should be a billion, million or thousand)</param>
        /// <param name="sbNumber">The output buffer that takes the parsed number using the specified base</param>
        /// <returns>The remainder of the original number minus the parsed base nuber. For example, if we had num = 1234 and the base was 1000, then this will be 234 and sbNumber will have "One Thousand" at the end</returns>
        private static int ExtractNumberFromBase(int num, int baseNumber, StringBuilder sbNumber)
        {
            Debug.Assert(new HashSet<int> { BILLION, MILLION, THOUSAND }.Contains(baseNumber));
            Debug.Assert(num >= THOUSAND);
            Debug.Assert(sbNumber != null);
            
            var sbContructedNumber = new StringBuilder();

            int divider = num / baseNumber; // we expect this to be between 1 and 999

            if (divider >= HUNDRED)
            {
                sbContructedNumber.Append(" "); // add a space for the remaining parts
                divider = ExtractHundreds(divider, sbContructedNumber);
            }

            if (divider >= TEN)
            {
                sbContructedNumber.Append(" ");
                divider = ExtractTens(divider, sbContructedNumber);
            }

            if (divider >= ONE)
            {
                sbContructedNumber.Append(" ");
                ExtractOnes(divider, sbContructedNumber);
            }

            string constructredNumberWords = 
                $"{sbContructedNumber.ToString().Trim()} { NUMBER_TO_ENGLISH_WORD[baseNumber] }";
            sbNumber.Append(constructredNumberWords);

            int numWithoutBillions = num % baseNumber;
            return numWithoutBillions;
        }
    }
}