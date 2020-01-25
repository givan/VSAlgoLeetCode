using System;
using System.Collections.Generic;

namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/combination-sum/
    // Difficulty: medium
    public class CombinaitionsSum
    {
        private SortedSet<int> candidatesSet; // possible integers that are less or equal to target

        public IList<IList<int>> Generate(int[] candidates, int target)
        {
            List<IList<int>> combinations = new List<IList<int>>();

            if (target <= 0) { return combinations.AsReadOnly(); };
            if (candidates == null || candidates.Length == 0) { return combinations.AsReadOnly(); }

            candidatesSet = new SortedSet<int>();
            foreach (var candidate in candidates)
            {
                // eliminate any values which are greater than target since they cannot be possible candidates
                if (candidate <= target)
                {
                    candidatesSet.Add(candidate);
                }
            }

            if (candidatesSet.Count == 0) { return combinations.AsReadOnly(); } // of the integers were greater than target

            List<int> currentPermuation = new List<int>(); // this will be holding the currently generated permuation of candidates
            CombinationsWithSum(target, currentPermuation, combinations);

            return combinations.AsReadOnly();
        }

        private void CombinationsWithSum(int sumTarget, List<int> currentPermuation, List<IList<int>> solutions)
        {
            // we're only interested at the candidates who are greaer than the last element in the current permutation
            // the reason for this is that we want to have unique combinations of possible digits in increasing order
            int maxCurrentCandidate = (currentPermuation.Count > 0) ? currentPermuation[currentPermuation.Count - 1] : 0; 

            // for each possible candidate for the current position - which are any candidates from the original set less or equal to sumTarget
            foreach (var candidate in candidatesSet)
            {
                if (candidate < maxCurrentCandidate) {
                    continue; // skip since we want to remove duplicate combinations
                    // everytime we getting only the combination where the candidates are in increasing order
                }

                if (candidate == sumTarget)
                {
                    // we just found a solution
                    currentPermuation.Add(candidate);
                    var newSolution = new List<int>(currentPermuation);
                    solutions.Add(newSolution.AsReadOnly());
                    currentPermuation.RemoveAt(currentPermuation.Count - 1); // we appeneded this to the end so now we're removing it
                }
                else if (candidate < sumTarget)
                {
                    currentPermuation.Add(candidate); // append it to the end of the current list

                    // try to find recursively other candidates whose sum will be the remainder of sumTarget - candidate
                    CombinationsWithSum(sumTarget - candidate, currentPermuation, solutions);

                    // clean up the current candidate from the current permutation
                    currentPermuation.RemoveAt(currentPermuation.Count - 1); // remove the last element since that's where we added it
                }
                else
                {
                    // since the candidatesSet is a sorted set in ascending order, so 
                    // at this point on we know any subsequent candidates will be greater and 
                    // hence we can stop searching now
                    break;
                }
            }
        }
    }
}