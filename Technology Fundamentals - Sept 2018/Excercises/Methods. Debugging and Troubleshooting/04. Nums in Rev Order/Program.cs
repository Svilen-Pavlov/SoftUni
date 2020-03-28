using System;

namespace _04._Nums_in_Rev_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            double result = ReverseNumber(input);
            Console.WriteLine(result);


        }

        private static double ReverseNumber(double number)
        {
            return double.Parse(ReverseString(number.ToString()));
        }

        private static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
