namespace Algo
{
    using System.Collections.Generic;
    using System.Text;

    // Solution for problem: https://leetcode.com/problems/reverse-words-in-a-string/
    // Difficulty: Medium
    // Results: Runtime: 104 ms, faster than 38.73% of C# online submissions for Reverse Words in a String.
    // Memory Usage: 25 MB, less than 14.29% of C# online submissions for Reverse Words in a String.
    
    public static class ReverseWords
    {
        public static string Solution(string s)
        {
            if (s == null || s.Length == 0) { return ""; }

            var words = new List<string>();

            int wordBeginIdx = 0;
            while (wordBeginIdx < s.Length)
            {

                // find the beginning of the current word (non space character)
                while (wordBeginIdx < s.Length && s[wordBeginIdx] == ' ') { wordBeginIdx++; }
                if (wordBeginIdx == s.Length) { break; } // we found only spaces so we're leaving now

                // now find the next space after wordBeginIdx
                // if no space is found, then we copy all characters between wordBeginIdx and last char in the string
                int nextSpaceIdx = wordBeginIdx + 1;
                while (nextSpaceIdx < s.Length && s[nextSpaceIdx] != ' ') { nextSpaceIdx++; }

                string currentWord = s[wordBeginIdx..nextSpaceIdx];
                words.Add(currentWord);

                wordBeginIdx = nextSpaceIdx + 1;
            }

            var sbReversedWords = new StringBuilder();

            if (words.Count > 0)
            {
                sbReversedWords.Append(words[^1]); // append the last word as it is (no space after it)

                for (int currentWordIdx = words.Count - 2; currentWordIdx >= 0; currentWordIdx--)
                {
                    // any other words we want to add them with a space before them
                    sbReversedWords.Append($" { words[currentWordIdx] }");
                }
            }

            return sbReversedWords.ToString();
        }
    }
}