using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public static class L1
    {
        public static string Run(string pathInputFile = "input.txt")
        {
            var inputInfo = File.ReadLines(pathInputFile).First().Split(' ');
            (int x, int k) = (Convert.ToInt32(inputInfo[0]) / 5, Convert.ToInt32(inputInfo[1]));
            return Convert.ToString((x + k).Factorial() / (x.Factorial() * k.Factorial()));
        }
    }

    public static class MyExtensions
    {
        public static int Factorial(this int number)
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
