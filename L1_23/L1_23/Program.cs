namespace L1_23
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputInfo = File.ReadLines("input.txt").First().Split(' ');
            (int x, int k) = (Convert.ToInt32(inputInfo[0]) / 5, Convert.ToInt32(inputInfo[1]));
            var outputFileInfo = new FileInfo("output.txt");
            using (StreamWriter streamWriter = outputFileInfo.CreateText())
            {
                streamWriter.WriteLine( (x + k).Factorial() / (x.Factorial() * k.Factorial()) );
            }
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