using System;

namespace _11._5_Different_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());


            if (Math.Abs(a - b) < 4)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = a; i <= b; i++)            //outer
                {
                    for (int j = a; j <= b; j++)       //inner
                    {
                        for (int k = a; k <= b; k++)
                        {
                            for (int l = a; l <= b; l++)
                            {
                                for (int m = a; m <= b; m++)
                                {
                                    if (i < j && j < k && k < l && l < m)
                                    {
                                        Console.Write($"{i} {j} {k} {l} {m}");
                                        Console.WriteLine();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
