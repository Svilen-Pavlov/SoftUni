using System;

namespace _08._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintClosest(x1, y1, x2, y2);
            //Math.sqrt( Math.pow(x, 2) + Math.pow(y, 2) );

        }

        private static void PrintClosest(double x1, double y1, double x2, double y2)
        {
            double distOne = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distTwo = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (distOne <= distTwo)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {

                Console.WriteLine($"({x2}, {y2})");

            }

        }
    }
}
