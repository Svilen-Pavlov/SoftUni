using System;

namespace _14._Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char bad = char.Parse(Console.ReadLine());
            string result = "";

            int fnum = Convert.ToInt32(first);
            int snum = Convert.ToInt32(second);
            int badnum = Convert.ToInt32(bad);


            for (int i = fnum; i <= snum; i++)
            {
                for (int j = fnum; j <= snum; j++)
                {

                    for (int k = fnum; k <= snum; k++)
                    {
                        if (i != badnum && j != badnum && k != badnum)
                        {
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");
                        }

                    }
                }
            }
        }
    }
}
