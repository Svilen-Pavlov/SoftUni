using System;

namespace _15._Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i <= input; i++)
            {
                bool isprime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isprime = false;
                        break;
                    }
                }
                if (i > 1)
                {
                    Console.WriteLine($"{i} -> {isprime}");
                }

            }
        }
    }
}
