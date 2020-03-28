using System;

namespace _13._Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int magicnum = int.Parse(Console.ReadLine());
            int targetsum = a + b;
            string result = "";
            int combos = 0;

            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    combos++;
                    if ((i + j) == magicnum)
                    {
                        result = $"{i} + {j} = {i + j}";

                    }

                }
            }

            if (result != "")
            {
                Console.WriteLine($"Number found! {result}");
            }
            else
            {
                Console.WriteLine($"{combos} combinations - neither equals {magicnum}");
            }

        }
    }
}
