using System;

namespace _05._Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            double result = GetFib(input);
            Console.WriteLine(result);


        }

        private static double GetFib(int input)
        {
            int first = 1;
            int second = 1;
            for (int i = 1; i < input; i++)
            {

                int temp = first;
                first = second;
                second = temp + second;


            }
            return second;

        }
    }
}
