using System;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Breadth-First Search");
            const int n = 4;
            int[,] GM = {
            {0,1,1,0},
            {0,0,1,1},
            {1,0,0,1},
            {0,1,0,0}
            };
            int inUnit; 
            bool[] vis = new bool[n];

            for (int i = 0; i < GM.GetLength(0); i++)
            {
                vis[i] = false;
                for(int j = 0; j < GM.GetLength(1); j++)
                {
                    Console.Write(GM[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Please enter the initial unit");
            inUnit = int.Parse(Console.ReadLine());
            Console.WriteLine("Visited nodes are displayed below: ");
            BFS(vis, inUnit - 1, GM);
        }
                                                                                                   
        static void BFS(bool[] passed, int unit, int[,] GM)
        {
            int[] queue = new int[GM.GetLength(0)]; // Создана очередь, что содержит посещённые узлы (без сдвига) в порядке посещения
            int count = 0; // количество уникальных(первых) посещений 
            int head = 0; // используется для посещения всех узлов графа, кроме изначального
            for (int i = 0; i < GM.GetLength(0); i++)
            {
                queue[i] = 0;
            }

            queue[count] = unit; // Изначальный узел помещается в очередь 
            count++;

            passed[unit] = true;  // Изначальный узел считается посещённым 

            while (head < count)
            {
                unit = queue[head];
                head++;  // Увеличение индекса, что является количеством узлов начиная с 0
                Console.WriteLine(unit+1);

                for (int i = 0; i < GM.GetLength(0); i++)
                { 
                    if ((!passed[i] && (GM[unit, i]==1))) // Если выполнено условия непосещённости узла и наличие связи с узлом i
                    {
                        queue[count] = i; // Узел помещается в очередь
                        count++;
                        passed[i] = true; // Узел считается посещённым 
                    }
                }
            }
        }
    }
}