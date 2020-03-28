using System;

namespace _07._Primes_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            long startnum = long.Parse(Console.ReadLine());
            long endnum = long.Parse(Console.ReadLine());

            PrintPrimes(startnum, endnum);



        }

        private static void PrintPrimes(long startnum, long endnum)
        {
            string result = "";
            for (long i = startnum; i <= endnum; i++)
            {
                if (PrimeCheck(i))
                {
                    result += $"{i}, ";
                }

            }
            result = result.Remove(result.Length - 2);
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
