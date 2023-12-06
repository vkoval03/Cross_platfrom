using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение входных данных из файла
        string inputFilePath = "INPUT.TXT";
        string outputFilePath = "OUTPUT.TXT";

        using (StreamReader reader = new StreamReader(inputFilePath))
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
             string line;
             while ((line = reader.ReadLine()) != null)
             {
                 string[] input = line.Split(' ');
                 int X = int.Parse(input[0]);
                 int K = int.Parse(input[1]);

                 // Виклик функції для знаходження кількості способів розділити гроші
                 int numberOfWays = CountWaysToDistributeMoney(X, K);

                 // Запис результату у вихідний файл
                 writer.WriteLine(numberOfWays);
             }
         }
     }

     static int CountWaysToDistributeMoney(int X, int K)
     {
         return BinomialCoefficient(X - 1, K - 1);
     }

     static int BinomialCoefficient(int n, int k)
     {
         if (k > n - k)
             k = n - k;

         int res = 1;

         for (int i = 0; i < k; ++i)
         {
             res *= (n - i);
             res /= (i + 1);
         }

         return res;
     }
}