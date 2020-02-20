using System;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter dimension of a matrix");
            int n = int.Parse(Console.ReadLine());
            bool determinant = true;
            double[,] A = new double[n, n];
            double[,] duplA = new double[n, n];
            double[,] B = new double[n, n];
            double[,] C = new double[n, n];
            double[,] D = new double[n, n];
            double[,] E = new double[n, n];
            try { 
                Console.WriteLine("Enter elements of the first matrix");

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A[i, j] = double.Parse(Console.ReadLine());
                        duplA[i, j] = A[i, j];
                    }
                }

                Console.WriteLine("Enter elements of the second matrix");

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        B[i, j] = double.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("Output (Sum): new matrix C");
                // Here I summrise two matrices
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                        Console.Write(C[i, j] + " ");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("Output (Multiplication): new matrix D");
                // Here I multiply two matrices
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            D[i, j] += A[i, k] * B[k, j];
                        }
                        Console.Write(D[i, j] + " ");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("Output (Inversed matrix A): new matrix E");
                // Creating of the identity matrix
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        E[i, i] = 1;
                    }
                }
                // Here I use Gauss algorithm to find an inversed matrix A (duplA)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            if ((duplA[i, j] == 0))
                            {
                                for (int t = i; t < n; t++)
                                {
                                    if (duplA[t, j] != 0)
                                    {
                                        for (int k = 0; k < n; k++)
                                        {
                                            double temp = duplA[t, k];
                                            duplA[t, k] = duplA[i, k];
                                            duplA[i, k] = temp;

                                            double temp2 = E[t, k];
                                            E[t, k] = E[i, k];
                                            E[i, k] = temp2;
                                        }
                                        inverse(duplA, E, j, n);
                                    }
                                }
                                throw new Exception("The determinant of the matrix A is 0, therefore matrix A is a singular matrix");
                            }
                            else
                                inverse(duplA, E, j, n);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                determinant = false;
            }
            //Here I print an inversed matrix
            if (determinant == true)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(E[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
            }
        }

        static void inverse(double[,] A, double[,] E, int rowcol, int n)
        {
            if (A[rowcol, rowcol] != 1)
            {
                double temp = A[rowcol, rowcol];
                for (int j = 0; j < n; j++)
                {
                    A[rowcol, j] = A[rowcol, j] / temp;
                    E[rowcol, j] = E[rowcol, j] / temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i != rowcol)
                {
                    double x = -A[i, rowcol] / A[rowcol, rowcol];

                    for (int j = 0; j < n; j++)
                    {
                        A[i, j] += A[rowcol, j] * x;
                        E[i, j] += E[rowcol, j] * x;
                    }
                }
            }
        }
    }
}