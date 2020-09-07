using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GRAPHS: ");
            int[,] firstCon = {
                {0,1,1,0,0},
                {1,0,0,1,1},
                {1,0,0,1,1},
                {0,1,1,0,0},
                {0,1,1,0,0}
            };
            Show(firstCon);

            int[,] firstInc = {
                {1,1,0,0,0,0},
                {1,0,1,1,0,0},
                {0,1,0,0,1,1},
                {0,0,1,0,0,1},
                {0,0,0,1,1,0}
            };
            Show(firstInc);

            int[,] SecondCon = {
                {0,1,1,0,0,0,0},
                {1,0,1,0,0,0,0},
                {1,1,0,1,1,1,0},
                {0,0,1,0,0,0,0},
                {0,0,1,0,0,0,1},
                {0,0,1,0,0,0,1},
                {0,0,0,0,1,1,0}
            };
            Show(SecondCon);

            int[,] SecondDirCon = {
                {0,1,1,0,0,0,0},
                {0,0,1,0,0,0,0},
                {0,0,0,1,1,1,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,1},
                {0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0}
            };
            Show(SecondDirCon);

            int[,] ThirdInc = {
                {1,1,0,0,0,0,0,0},
                {0,1,1,0,0,0,0,0},
                {1,0,1,1,1,1,0,0},
                {0,0,0,1,0,0,0,0},
                {0,0,0,0,1,0,0,1},
                {0,0,0,0,0,1,1,0},
                {0,0,0,0,0,0,1,1}
            };
            Show(ThirdInc);

            int[,] ThirdDirInc = {
                {1,1,0,0,0,0,0,0},
                {0,-1,1,0,0,0,0,0},
                {-1,0,-1,1,1,1,0,0},
                {0,0,0,-1,0,0,0,0},
                {0,0,0,0,-1,0,0,1},
                {0,0,0,0,0,-1,1,0},
                {0,0,0,0,0,0,-1,-1}
            };
            Show(ThirdDirInc);
            
        }

        static void Show(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}


