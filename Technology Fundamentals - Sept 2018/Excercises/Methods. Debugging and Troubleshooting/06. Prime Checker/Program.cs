using System;

namespace _06._Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());

            bool result = PrimeCheck(input);
            Console.WriteLine(result);


        }

        private static bool PrimeCheck(long input)
        {
            bool result = true;
            if (input == 0 || input == 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(input); i++)
            {
                if (input % i == 0)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
