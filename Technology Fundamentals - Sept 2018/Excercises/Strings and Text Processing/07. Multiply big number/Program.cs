using System;
using System.Text;

namespace _07._Multiply_big_number
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder first = new StringBuilder(Console.ReadLine().TrimStart('0'));
            int second = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            double product = 0;
            double remainder = 0;
            int numInMind = 0;
            int power = 1;
            if (second == 0)
            {
                Console.WriteLine(0); return;
            }
            else
            {

                for (int i = 0; i < first.Length; i++)
                {
                    double last = double.Parse(first[first.Length - 1 - i].ToString());

                    product = second * last + numInMind;
                    remainder = product % 10;
                    numInMind = (int)product / 10;

                    result.Insert(0, remainder);
                    if (i == first.Length - 1 && numInMind != 0)
                    {
                        result.Insert(0, numInMind);
                    }
                    power++;
                }
                Console.WriteLine(result);
            }
        }
    }
}
