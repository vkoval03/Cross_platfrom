using System;

namespace LabsLibrary
{
    public class L3Manager
    {
        private readonly string[] _lines;

        public L3Manager(string[] lines)
        {
            _lines = lines;
        }

        public string Run()
        {
            string[] firstLine = _lines[0].Split();
            int N = Convert.ToInt32(firstLine[0]);
            int M = Convert.ToInt32(firstLine[1]);

            int[,] graph = new int[N + 1, N + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    graph[i, j] = int.MaxValue;
                }
            }

            for (int i = 1; i <= M; i++)
            {
                string[] road = _lines[i].Split();
                int city1 = Convert.ToInt32(road[0]);
                int city2 = Convert.ToInt32(road[1]);
                graph[city1, city2] = 0;
                if (graph[city2, city1] != 0)
                {
                    graph[city2, city1] = 1;
                }
            }

            int minK = GetRes(graph, N);
            return minK.ToString();
        }

        private int GetRes(int[,] graph, int N)
        {
            for (int k = 1; k <= N; k++)
            {
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        if (graph[i, k] != int.MaxValue && graph[k, j] != int.MaxValue)
                        {
                            graph[i, j] = Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                        }
                    }
                }
            }

            int maxDist = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = i + 1; j <= N; j++)
                {
                    maxDist = Math.Max(maxDist, graph[i, j]);
                }
            }

            return maxDist;
        }
    }
}
