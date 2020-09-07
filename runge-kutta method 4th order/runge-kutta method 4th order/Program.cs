using System;

namespace runge_kutta_method_4th_order
{
    class Program
    {
        static double Dydx(double x, double y)
        {
            return ((x - y) / 2);
        }

        static double rungeKutta(double x0, double y0, double x, double h)
        {
            int n = (int) ((x - x0) / h);

            double k1, k2, k3, k4;

            double y = y0;

            for (int i = 1; i <= n; i++)
            {
                k1 = h * (Dydx(x0, y));

                k2 = h * (Dydx(x0 + 0.5 * h, y + 0.5 * k1));

                k3 = h * (Dydx(x0 + 0.5 * h, y + 0.5 * k2));

                k4 = h * (Dydx(x0 + h, y + k3));

                y = y + (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);

                x0 = x0 + h;
            }

            return y;
        }

        static void Main()
        {

            double x0, y, x, h;
            Console.WriteLine("Enter x0: ");
            x0 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter y: ");
            y = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter x: ");
            x = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter h: ");
            h = double.Parse(Console.ReadLine());
            Console.WriteLine("\nThe value of y"
                                 + " at x is : "
                     + rungeKutta(x0, y, x, h));
        }
    }
}
