namespace _3_lab
{
    public class Lab_3
    {
        public void Run(string input, string output)
        {
        	// Чтение входных данных из файла
        	string[] inputLines = File.ReadAllLines("INPUT.TXT");
        	string[] firstLine = inputLines[0].Split(' ');
        	int N = int.Parse(firstLine[0]);
        	int M = int.Parse(firstLine[1]);

        	// Зчитуємо дані про дороги
        	List<int>[] roads = new List<int>[N];
        	for (int i = 0; i < N; i++)
        	{
            		roads[i] = new List<int>();
        	}

        	for (int i = 1; i <= M; i++)
        	{
            		string[] roadInfo = inputLines[i].Split(' ');
            		int startCity = int.Parse(roadInfo[0]) - 1;
            		int endCity = int.Parse(roadInfo[1]) - 1;

            		roads[startCity].Add(endCity);
        	}

        	int minK = FindMinK(N, roads);

        	// Виведення результату на екран
        	File.WriteAllText("OUTPUT.TXT", minK.ToString());
        }

        static int FindMinK(int N, List<int>[] roads)
        {
            // Для кожної пари міст перевіряємо чи існує маршрут
            // (можливо, з порушенням правил) між ними
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        bool[] visited = new bool[N];
                        if (!HasPath(roads, visited, i, j))
                        {
                            return 1; // Якщо існує маршрут без порушення правил, K = 1
                        }
                    }
                }
            }

            // Якщо для кожної пари міст існує маршрут, K = 2
            return 2;
        }

        static bool HasPath(List<int>[] roads, bool[] visited, int start, int end)
        {
            visited[start] = true;

            if (start == end)
            {
                return true;
            }

            foreach (int neighbor in roads[start])
            {
                if (!visited[neighbor])
                {
                    if (HasPath(roads, visited, neighbor, end))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}