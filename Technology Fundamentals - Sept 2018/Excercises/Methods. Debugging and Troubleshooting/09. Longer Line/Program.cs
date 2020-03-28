using System;

namespace _09._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());  //firstline
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());  //secondline
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());


            double lengthOne = CalcDistance(x1, y1, x2, y2);
            double lengthTwo = CalcDistance(x3, y3, x4, y4);
            if (lengthOne > lengthTwo)
            {
                PrintClosestFirst(x1, y1, x2, y2);
            }
            else
            {
                PrintClosestFirst(x3, y3, x4, y4);
            }




        }

        private static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return distance;
        }

        private static void PrintClosestFirst(double x1, double y1, double x2, double y2)
        {
            double distOne = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distTwo = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (distOne <= distTwo)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");

            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");


            }

        }
    }
}
