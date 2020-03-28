using System;
using System.Numerics;

namespace _13._Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            PrintFactorial(n);


        }

        private static void PrintFactorial(BigInteger n)
        {
            BigInteger result = n;
            for (BigInteger i = 1; i < n; i++)
            {
                result = result * i;
            }
            Console.WriteLine(result);
        }
    }
}
