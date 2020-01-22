using System;
namespace Algo
{
    public static class FindMaxProfit
    {
        // PROBLEM: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/
        public static int Solve(int[] prices)
        {
            if (prices == null || prices.Length < 1)
            {
                return 0;
            }

            // try to find increase first
            // we want to determine if rising or dropping price is here
            // we also want to purchase when the price is rising at the lowest point
            int profit = 0;

            int currentTickIdx = 1; // start from the second element until the end
            while (currentTickIdx < prices.Length)
            {

                if (prices[currentTickIdx - 1] < prices[currentTickIdx])
                { // the prices are climbing
                    // this is the first time when we see the spike in price so we need to keep the first price
                    int buyPrice = prices[currentTickIdx - 1];

                    // now move the current element until we find the highest point at which the prices start going down or we reach the end of hte samples
                    while (currentTickIdx < prices.Length && prices[currentTickIdx - 1] <= prices[currentTickIdx])
                    {
                        currentTickIdx++;
                    }

                    if (currentTickIdx == prices.Length)
                    { // just get the last sample in the array
                        currentTickIdx--;
                    }

                    int sellPrice = prices[currentTickIdx];

                    profit += (sellPrice - buyPrice);
                }
                
                // for any other cases, we simply move the index to the right until we find an increasing sequence
                currentTickIdx++;
            }

            return profit;
        }
    }
}
