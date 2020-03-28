using System;

namespace _10._Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            double result = CalcParam(a, parameter);
            Console.WriteLine($"{result:f2}");

        }

        private static double CalcParam(double a, string param)
        {
            double result = 0;
            if (param == "face")
            {
                result = Math.Sqrt(2 * a * a);
            }
            else if (param == "space")
            {
                result = Math.Sqrt(3 * a * a);
            }
            else if (param == "volume")
            {
                result = a * a * a;
            }
            else if (param == "area")
            {
                result = 6 * a * a;
            }
            return result;
        }
    }
}
