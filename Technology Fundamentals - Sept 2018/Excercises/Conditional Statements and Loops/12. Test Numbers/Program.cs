using System;

namespace _12._Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int sumlimit = int.Parse(Console.ReadLine());
            int count = 0;
            int sum = 0;

            for (int i = a; i >= 1; i--)
            {
                for (int j = 1; j <= b; j++)
                {
                    sum += 3 * (i * j);
                    count++;
                    if (sum >= sumlimit)
                    {
                        break;
                    }
                }
                if (sum >= sumlimit)
                {
                    break;
                }
            }
            Console.WriteLine($"{count} combinations");
            if (sum >= sumlimit)
            {
                Console.WriteLine($"Sum: {sum} >= {sumlimit}");
            }
            else
            {
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
