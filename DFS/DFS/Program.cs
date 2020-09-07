using System;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;

            bool[] visited = new bool[n];
            int[,] graph =
            {
            {0,1,0,0,1},
            {1,0,1,1,1},
            {0,1,0,0,1},
            {0,1,0,0,1},
            {1,0,1,1,1}
            };


            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
                for (int j = 0; j < n; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Please write down the initial knot");
            int st = int.Parse(Console.ReadLine());
            Console.WriteLine("Visited nodes are displayed below:");
            DFS(st - 1, visited, graph);
        }

        static void DFS(int st, bool[] visited, int[,] graph)
        {
            Console.WriteLine(st+1);
            visited[st] = true; // входное значение st - индекс узла в массиве 
            for (int r = 0; r < graph.GetLength(0); r++)
            {
                if ((graph[st, r] != 0) && (!visited[r])) // Условие: если имеется связь (т.е. !=0) и узел не посещён
                {
                    DFS(r, visited, graph); // Вызов функции с измененнымми значениям / проход вглубь / рекурсивынй вызов 
                }
            }
        }
    }
}