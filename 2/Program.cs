using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFilePath = "INPUT.txt";
        string outputFilePath = "output.txt";

        try
        {
            string input = File.ReadAllText(inputFilePath);
            int N = int.Parse(lines[0]);
            int[] coinValues = lines[1].Split(' ').Select(int.Parse).ToArray();
            int K = int.Parse(lines[2]);
            int[] targetSums = lines[3].Split(' ').Select(int.Parse).ToArray();

            bool[] results = new bool[K];
            for (int i = 0; i < K; i++)
            {
                results[i] = CanExchange(coinValues, targetSums[i]);
            }

            // Записуємо результат у вихідний файл
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(string.Join(" ", results.Select(result => result ? 1 : 0)));
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл INPUT.TXT не знайдено.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Некоректний формат даних у файлі INPUT.TXT.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Виникла помилка: " + ex.Message);
        }

        Console.ReadLine();
    }

    // Функція для перевірки, чи можна розміняти суму грошей монетами заданих переваг
    static bool CanExchange(int[] coinValues, int targetSum)
    {
        bool[] dp = new bool[targetSum + 1];
        dp[0] = true;

        foreach (int coinValue in coinValues)
        {
            for (int i = targetSum; i >= coinValue; i--)
            {
                dp[i] = dp[i] || dp[i - coinValue];
            }
        }

        return dp[targetSum];
    }
}