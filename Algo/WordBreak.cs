using System;
using System.Collections.Generic;

namespace Algo {
    // Solution for problem: https://leetcode.com/problems/word-break/
    // Difficulty: medium
    // Area: Dynamic programming
    // Approach 2: Recursion with memoization
    // Runtime: 100 ms, faster than 91.09% of C# online submissions for Word Break.
    // Memory Usage: 24.7 MB, less than 83.33% of C# online submissions for Word Break.
    public static class WordBreakDP
    {
        public static bool CanBeBrokenDown(string input, IList<string> words)
        {
            Dictionary<int, List<string>> indexToWords = BuildIndexToWordsMap(input, words);

            Dictionary<int, bool> memo = new Dictionary<int, bool>(); // used to keep results for index to if found a breakdown (dynamic programming)
            bool foundBreakdown = HasBreakDownStartingAtIndex(input, 0, indexToWords, memo);

            return foundBreakdown;
        }

        private static Dictionary<int, List<string>> BuildIndexToWordsMap(string input, IList<string> words)
        {
            var indexToWords = new Dictionary<int, List<string>>();

            foreach (var word in words)
            {
                int startingIdx = 0, foundIdx = 0;
                while (foundIdx >= 0)
                {
                    foundIdx = input.IndexOf(word, startingIdx, StringComparison.InvariantCulture);
                    if (foundIdx >= 0)
                    {
                        if (!indexToWords.TryGetValue(foundIdx, out var wordsAtIndex)) {
                            wordsAtIndex = new List<string>();
                            indexToWords[foundIdx] = wordsAtIndex;
                        }

                        wordsAtIndex.Add(word);

                        startingIdx = foundIdx + 1;
                    }
                }
            }

            return indexToWords;
        }

        private static bool HasBreakDownStartingAtIndex(string input,
                                                        int currentIndex,
                                                        Dictionary<int, List<string>> indexToWords,
                                                        Dictionary<int, bool> memo)
        {
            bool foundBreakdown = false;

            if (memo.ContainsKey(currentIndex)) {
                return memo[currentIndex]; // if prevoiusly we calculated the result at this index, we don't need to calculate it again (DP)
            } 

            if (indexToWords.TryGetValue(currentIndex, out var wordsAtIndex)) {
                foreach (var currentWord in wordsAtIndex)
                {
                    int nextWordStartIdx = currentIndex + currentWord.Length;
                    
                    if (nextWordStartIdx == input.Length) // we found an exact match ending with the currentWord
                    {
                        foundBreakdown = true;
                        break;
                    }
                    else if (nextWordStartIdx < input.Length) {
                        foundBreakdown = HasBreakDownStartingAtIndex(input, nextWordStartIdx, indexToWords, memo);
                        if (foundBreakdown) { 
                            break;  // we found a solution so no need to keep on searching for more
                        }
                    }
                }
            }

            // store the result for the current index
            memo.Add(currentIndex, foundBreakdown);

            return foundBreakdown;
        }
    }
}