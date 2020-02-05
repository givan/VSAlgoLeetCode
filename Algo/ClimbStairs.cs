namespace Algo
{
    // Solution for problem: https://leetcode.com/problems/climbing-stairs/
    // Difficulty: Easy
    // Runtime: 32 ms, faster than 99.22% of C# online submissions for Climbing Stairs.
    // Memory Usage: 14.5 MB, less than 5.88% of C# online submissions for Climbing Stairs.
    public static class ClimbStairs
    {
        public static int CombinationsToStair(int stairsCount)
        {
            if (stairsCount == 1) { return 1; }
            if (stairsCount == 2) { return 2; }

            // keep track of the last two count of combinations counts
            int combosTwoStepsBefore = 1; // combos 2 steps before current
            int combosOneStepBefore = 2; // combos 1 step before current
            int currentStep = 2; // current step count

            int expectedCombos = 0;
            while(currentStep < stairsCount) {
                expectedCombos = combosOneStepBefore + combosTwoStepsBefore;

                // move to the next steps count adjusting the previous two steps counts accordingly
                combosTwoStepsBefore = combosOneStepBefore;
                combosOneStepBefore = expectedCombos;
                currentStep++;
            }

            // similar to fibonacci - at each of the ways to get to stair n-2, we can do after that a 2 stair jump
            // also for each of the ways to get to stair n-1, we can do one more stair and we'll get to the nth stair
            // hence the number of combos to get to the nth stair, are equal to the sum of the combos to get to n-1 and n-2 stairs
            return expectedCombos;
        }
    }
}