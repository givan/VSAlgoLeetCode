namespace Algo
{
    using System;
    using System.Collections.Generic;

    // Solution for problem: https://leetcode.com/problems/letter-combinations-of-a-phone-number/
    // Difficulty: Medium
    // Runtime: 240 ms, faster than 69.26% of C# online submissions for Letter Combinations of a Phone Number.
    // Memory Usage: 31.7 MB, less than 6.67% of C# online submissions for Letter Combinations of a Phone Number.

    public static class PhoneNumberCombinations
    {
        private static readonly Dictionary<char, char[]> DIGIT_TO_LETTERS = new Dictionary<char, char[]>()
        {
            {'2', new [] {'a', 'b', 'c'}},
            {'3', new [] {'d', 'e', 'f'}},
            {'4', new [] {'g', 'h', 'i'}},
            {'5', new [] {'j', 'k', 'l'}},
            {'6', new [] {'m', 'n', 'o'}},
            {'7', new [] {'p', 'q', 'r', 's'}},
            {'8', new [] {'t', 'u', 'v'}},
            {'9', new [] {'w', 'x', 'y', 'z'}},
        };

        public static IList<string> LetterCombinations(string digits)
        {
            // keep a list of all currently generated phones
            // have a temp List for the currently generated phone number
            var listOfWords = new List<string>();
            var currentPhone = new List<char>();

            if (!string.IsNullOrEmpty(digits)) {
                GenerateWordsFromDigits(digits, currentPhone, listOfWords);
            }

            return listOfWords.AsReadOnly();
        }

        private static void GenerateWordsFromDigits(string digits, List<char> currentWord, List<string> generatedWords)
        {
            if (digits.Length <= currentWord.Count)
            {
                string newWord = new string(currentWord.ToArray());
                generatedWords.Add(newWord);
                return;
            }

            char currDigit = digits[currentWord.Count];

            if (DIGIT_TO_LETTERS.ContainsKey(currDigit))
            {
                char[] possibleLetters = DIGIT_TO_LETTERS[currDigit];
                foreach (var currChar in possibleLetters)
                {
                    currentWord.Add(currChar); // append to the end
                    GenerateWordsFromDigits(digits, currentWord, generatedWords);
                    currentWord.RemoveAt(currentWord.Count - 1); // remove the last character that we added in the same iteration
                }
            }
            else
            {
                throw new ArgumentException($"digits parameter contains unexpected characted: { currDigit }. Should contain any digit from 2-9");
            }
        }
    }
}