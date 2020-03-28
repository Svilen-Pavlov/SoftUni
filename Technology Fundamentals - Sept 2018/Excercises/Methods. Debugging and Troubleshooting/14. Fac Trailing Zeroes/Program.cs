using System;
using System.Numerics;

namespace _14._Fac_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger nFact = GetFactorial(n);
            BigInteger trailing = GetTrailing(nFact);
            Console.WriteLine(trailing);
        }

        private static BigInteger GetTrailing(BigInteger nFact)
        {
            BigInteger count = 0;
            for (BigInteger i = 0; i < nFact.ToString().Length; i++)
            {
                if (nFact % 10 != 0)
                {
                    break;
                }
                nFact = nFact / 10; count++;
            }
            return count;
        }

        private static BigInteger GetFactorial(BigInteger n)
        {
            BigInteger result = n;
            for (BigInteger i = 1; i < n; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}
