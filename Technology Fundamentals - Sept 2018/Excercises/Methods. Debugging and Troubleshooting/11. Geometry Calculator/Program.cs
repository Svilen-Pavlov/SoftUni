using System;

namespace _11._Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double a = 0;
            double b = 0;
            string fig = "";
            if (figure == "triangle")
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                fig = "t";
            }
            else if (figure == "square")
            {
                a = double.Parse(Console.ReadLine());
                b = a;
                fig = "s";
            }
            else if (figure == "rectangle")
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                fig = "r";
            }
            else if (figure == "circle")
            {
                a = double.Parse(Console.ReadLine());
                b = Math.PI;
                fig = "c";
            }



            double result = CalcArea(a, b, fig);
            Console.WriteLine($"{result:f2}");

        }

        private static double CalcArea(double a, double b, string fig)
        {
            double result = 0;
            if (fig == "t")
            {
                result = a * b / 2;
            }
            else if (fig == "s" || fig == "r")
            {
                result = a * b;
            }
            else if (fig == "c")
            {
                result = b * a * a;
            }
            return result;
        }
    }
}
