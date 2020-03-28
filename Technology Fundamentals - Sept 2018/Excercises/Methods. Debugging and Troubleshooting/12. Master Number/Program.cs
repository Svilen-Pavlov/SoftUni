using System;

namespace _12._Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMaster(n);


        }

        private static void PrintMaster(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if ((SumDigitsDivby7(i) == true) && (Palin(i) == true) && (OneEven(i) == true))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool OneEven(int i)
        {
            int counter = i.ToString().Length;
            for (int j = 0; j < counter; j++)
            {
                if (i % 2 == 0)
                {
                    return true;
                }
                i = i / 10;
            }
            return false;
        }

        private static bool SumDigitsDivby7(int i)
        {
            int sumofdigits = 0;
            int counter = i.ToString().Length;
            for (int j = 0; j < counter; j++)
            {
                int temp = i;
                sumofdigits += temp % 10;
                i = i / 10;

            }
            if (sumofdigits % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool Palin(int i)
        {
            int n = i;
            int dig;
            double rev = 0;
            while (i > 0)
            {
                dig = i % 10;
                rev = rev * 10 + dig;
                i = i / 10;
            }
            if (n == rev)
            {
                //Console.WriteLine("pali");
                return true;
            }
            else
            {
                //Console.WriteLine("nopali");
                return false;
            }

        }
    }
}
