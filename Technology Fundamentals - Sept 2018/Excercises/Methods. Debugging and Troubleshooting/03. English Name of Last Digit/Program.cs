using System;

namespace _03._English_Name_of_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());

            string result = GetName(input);
            Console.WriteLine(result);
        }

        private static string GetName(long input)
        {
            int lastdigit;
            string result = "";

            input = input % 10;

            lastdigit = (int)input;

            switch (lastdigit)
            {
                case 1:
                case -1: result = "one"; break;
                case -2:
                case 2: result = "two"; break;
                case -3:
                case 3: result = "three"; break;
                case -4:
                case 4: result = "four"; break;
                case -5:
                case 5: result = "five"; break;
                case -6:
                case 6: result = "six"; break;
                case -7:
                case 7: result = "seven"; break;
                case -8:
                case 8: result = "eight"; break;
                case -9:
                case 9: result = "nine"; break;
                case 0: result = "zero"; break;

            }
            return result;
        }
    }
}
