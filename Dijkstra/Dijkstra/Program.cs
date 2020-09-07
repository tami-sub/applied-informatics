using System;

namespace Dijkstra
{
    class Program
    { 
        static void Main()
        {
            Console.WriteLine("Enter the initial node");
            int start = int.Parse(Console.ReadLine());

            int[,] GR =
            {
                {0,1,4,0,2,0},
                {0,0,0,9,0,0},
                {4,0,0,7,0,0},
                {0,9,7,0,0,2},
                {0,0,0,0,0,8},
                {0,0,0,0,0,0}  
            };

            for (int i = 0; i < GR.GetLength(0); i++)
            {
                for (int j = 0; j < GR.GetLength(0); j++)
                {
                    Console.Write(GR[i,j] + " ");
                }
                Console.WriteLine();
            }
            Dijkstra(GR, start-1);
        }
        static void Dijkstra(int[,] GR, int st)
        {
            int[] distance = new int[GR.GetLength(0)];// Массив значений дистанций от данного узла до остальных (включая данный)
            int u; // Переменная для хранения индека узла с наименьщей дистанцией  
            int index = 0;
            int m = st + 1; // Реальное значение(номер) узла
            bool[] visited = new bool[GR.GetLength(0)]; // Массив посещений 

            for (int i = 0; i < GR.GetLength(0); i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[st] = 0; // Дистанция от данного узла до самого себя, то есть 0

            for (int count = 0; count < GR.GetLength(0) - 1; count++)
            {
                index = MinimumDistance(GR, distance, index, visited); // Индекс Узла с минисальным значение 
                u = index;
                visited[u] = true; // Узел с минимальным значением считается посещённым
                for (int i = 0; i < GR.GetLength(0); i++)
                {
                    if (!visited[i] && Convert.ToBoolean(GR[u, i]) && distance[u] != int.MaxValue && distance[u] + GR[u, i] < distance[i]) // Нахождение наименьшего пути 
                        distance[i] = distance[u] + GR[u, i];
                }
            }
            Print(GR, distance, m);
        }

        private static void Print(int[,] GR, int[] distance, int m)
        {
            Console.WriteLine("Price of the way feom the initial not to others");
            for (int i = 0; i < GR.GetLength(0); i++)
            {
                if (distance[i] != int.MaxValue)
                {
                    Console.WriteLine(m + " > " + (i + 1) + " = " + distance[i]);
                }
                else
                {
                    Console.WriteLine(m + " > " + (i + 1) + " = " + "Маршрут недоступен");
                }
            }
        }

        private static int MinimumDistance(int[,] GR, int[] distance, int index, bool[] visited)
        {
            int min = int.MaxValue;
            for (int i = 0; i < GR.GetLength(0); i++)
            {
                if (!visited[i] && distance[i] <= min) // Условие: Если узел не посещён и дтекущая дистанция меньше минимальной
                {
                    min = distance[i];
                    index = i;
                }
            }

            return index; // возвращение индекса узла, что находится на минимальном расстоянии от данного и при это не был посещён
        }
    }
}
