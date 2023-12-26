using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public static class L2
    {
        public static string Run(string pathInputFile = "input.txt")
        {
            string[] lines = File.ReadAllLines(pathInputFile);
            int[] coins = lines[1].Split(' ').Select(num => Convert.ToInt32(num)).ToArray();
            int[] sums = lines[3].Split(' ').Select(num => Convert.ToInt32(num)).ToArray();

            int[] result = CalculateChangePossibility(coins, sums);
            return string.Join(" ", result);
        }

        static int[] CalculateChangePossibility(int[] coins, int[] sums)
        {
            int[] result = new int[sums.Length];

            for (int i = 0; i < sums.Length; i++)
            {
                result[i] = CanChange(coins, sums[i]) ? 1 : 0;
            }

            return result;
        }

        static bool CanChange(int[] coins, int target)
        {
            bool[] dp = new bool[target + 1];
            dp[0] = true;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= target; j++)
                {
                    dp[j] |= dp[j - coins[i]];
                }
            }

            return dp[target];
        }
    }
}
