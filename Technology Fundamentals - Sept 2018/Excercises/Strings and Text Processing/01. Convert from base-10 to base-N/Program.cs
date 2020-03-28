using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _01._Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            BigInteger Base = BigInteger.Parse(input[0]);
            BigInteger num = BigInteger.Parse(input[1]);
            BigInteger remainder = 0;

            StringBuilder result = new StringBuilder();
            BigInteger counter = 0;

            while (true)
            {
                counter++;

                remainder = num % Base;
                result.Append(remainder.ToString());
                num = (num - remainder) / Base;
                if (num == 0)
                {
                    break;
                }
            }
            string newresult = result.ToString();
            string newresult2 = new string(newresult.Reverse().ToArray());
            Console.WriteLine(newresult2);
        }
    }
}
