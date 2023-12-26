namespace LabsLibrary
{
    public class L2Manager
    {
        private readonly int[] _coins;
        private readonly int[] _sums;

        public L2Manager(int[] coins, int[] sums)
        {
            _coins = coins;
            _sums = sums;
        }

        public string Run()
        {
            return string.Join(" ", CalculateChangePossibility());
        }

        private int[] CalculateChangePossibility()
        {
            int[] result = new int[_sums.Length];

            for (int i = 0; i < _sums.Length; i++)
            {
                result[i] = CanChange(_sums[i]) ? 1 : 0;
            }

            return result;
        }

        private bool CanChange(int target)
        {
            bool[] dp = new bool[target + 1];
            dp[0] = true;

            for (int i = 0; i < _coins.Length; i++)
            {
                for (int j = _coins[i]; j <= target; j++)
                {
                    dp[j] |= dp[j - _coins[i]];
                }
            }

            return dp[target];
        }
    }
}
