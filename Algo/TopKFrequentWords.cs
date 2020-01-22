using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

// Solution for https://leetcode.com/problems/top-k-frequent-words/
public static class TopKFrequentWords
{
    public static IList<string> TopKFrequent(string[] words, int k)
    {
        List<string> result = new List<string>();

        if (words == null || words.Length == 0)
        {
            return result;
        }

        if (k <= 0)
        {
            return result;
        }

        // first iterate over all words and count how many times each word counts
        Dictionary<string, int> wordsToCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            wordsToCount.TryGetValue(word, out int count);
            count++;
            wordsToCount[word] = count;
        }

        // then in a sorted set, keep the top k used words
        SortedSet<WordCount> topKFoundWords = new SortedSet<WordCount>(new WordCountComparer());
        foreach (var word in wordsToCount.Keys)
        {
            WordCount currentWordCount = new WordCount(word, wordsToCount[word]);
            topKFoundWords.Add(currentWordCount);

            if (topKFoundWords.Count > k)
            {
                // remove the min element
                topKFoundWords.Remove(topKFoundWords.Min);
            }
        }

        // finally iterate over the sorted set to retrieve the top k used words
        while (topKFoundWords.Any())
        {
            WordCount currentMax = topKFoundWords.Max;
            result.Add(currentMax.Word);
            topKFoundWords.Remove(currentMax);
        }

        return result;
    }
}

class WordCount
{
    public string Word { get; private set; }
    public int Count { get; private set; }

    public WordCount(string word, int count)
    {
        Word = word;
        Count = count;
    }
}

class WordCountComparer : Comparer<WordCount>
{
    public override int Compare([AllowNull] WordCount x, [AllowNull] WordCount y)
    {
        if (x == null && y == null) return 0;
        if (x == null && y != null) return 1;
        if (x != null && y == null) return -1;

        if (x.Count == y.Count)
        {
            // If two words have the same frequency, then the word with the lower alphabetical order comes first.
            // becase we're generating decreasing sequence, we want to first return the bigger and then the smaller string
            // based on their alphabetical order; for example, if we have "i" and "love", then "i" has lower alphabetical order than "love"
            // however the requirement here is to return "i" before "love" hence for the wordCount element we need to inverse by sign
            // the comparison result from the word values
            return string.CompareOrdinal(x.Word, y.Word) * (-1);
        }

        return x.Count.CompareTo(y.Count);
    }
}