namespace L2_23
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            int[] coins = lines[1].Split(' ').Select(num => Convert.ToInt32(num)).ToArray();
            int[] sums = lines[3].Split(' ').Select(num => Convert.ToInt32(num)).ToArray();

            int[] result = CalculateChangePossibility(coins, sums);
            File.WriteAllText("output.txt", string.Join(" ", result));
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