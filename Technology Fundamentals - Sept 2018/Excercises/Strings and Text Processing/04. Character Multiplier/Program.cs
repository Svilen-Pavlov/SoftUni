using System;
using System.Linq;
using System.Text;

namespace _04._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            StringBuilder first = new StringBuilder(input[0]);
            StringBuilder second = new StringBuilder(input[1]);
            StringBuilder leftover = new StringBuilder();
            int firstLen = first.Length;
            int secondLen = second.Length;

            int bigger = Math.Max(firstLen, secondLen);
            int diff = Math.Abs(firstLen - secondLen);
            int sum = 0;

           
            int counter = 0;
            for (int i = 0; i < bigger - diff; i++)
            {
                int one = first[i];
                int two = second[i];
                sum += one * two;
                counter++;
            }
            if (firstLen > secondLen)
            {
                for (int i = counter; i < firstLen; i++)
                {
                    sum += first[i];
                }
            }
            else if (secondLen > firstLen)
            {
                for (int i = counter; i < secondLen; i++)
                {
                    sum += second[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
