using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _02._Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            int Base = int.Parse(input[0]);
            BigInteger num = BigInteger.Parse(input[1]);
            BigInteger result = 0;
            StringBuilder resultSB = new StringBuilder();
            StringBuilder numSB = new StringBuilder(input[1]);
            BigInteger power = 0;
            int currentDigit = 0;
            BigInteger currRes = 0;
            int len = numSB.Length;

            for (int i = 0; i < len; i++)
            {
                currentDigit = int.Parse(numSB[numSB.Length - 1 - i].ToString());

                power = BigInteger.Pow(Base, i);
                currRes = currentDigit * power;
                result += currRes;
                power++;
            }
            Console.WriteLine(result);

        }
    }
}
