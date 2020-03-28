using System;
using System.Linq;

namespace _06._Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = Console.ReadLine();
            string input = ReverseString(original);
            int[] arr = input.Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];


            }
            Console.WriteLine(sum);
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
