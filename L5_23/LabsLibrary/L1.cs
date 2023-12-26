using System;

namespace LabsLibrary
{
    public class L1Manager
    {
        private readonly int _x;
        private readonly int _k;

        public L1Manager (int x, int k)
        {
            _x = x / 5;
            _k = k;
        }

        public string Run()
        {
            return Convert.ToString(CalculateFactorial(_x + _k) / (CalculateFactorial(_x) * CalculateFactorial(_k)));
        }

        private int CalculateFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Factorial is defined only for non-negative integers.");
            }

            int result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
