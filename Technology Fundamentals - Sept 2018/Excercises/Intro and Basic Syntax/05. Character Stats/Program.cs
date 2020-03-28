using System;

namespace _05._Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currenthp = int.Parse(Console.ReadLine());
            int maxhp = int.Parse(Console.ReadLine());
            int currentmp = int.Parse(Console.ReadLine());
            int maxmp = int.Parse(Console.ReadLine());

            int currenthpBars = 0;
            int currentmpBars = 0;
            for (int i = 0; i < currenthp; i++)
            {
                currenthpBars++;
            }
            int hpdots = maxhp - currenthpBars;
            for (int i = 0; i < currentmp; i++)
            {
                currentmpBars++;
            }
            int mpdots = maxmp - currentmpBars;



            Console.WriteLine($"Name: {name}");
            Console.Write($"Health: |"); //start bracket
            for (int i = 0; i < currenthpBars; i++)
            {
                Console.Write($"|");
            }
            for (int i = 0; i < hpdots; i++)
            {
                Console.Write($".");
            }
            Console.Write($"|"); //end bracket
            Console.WriteLine();
            Console.Write($"Energy: |"); //start bracket
            for (int i = 0; i < currentmpBars; i++)
            {
                Console.Write($"|");
            }
            for (int i = 0; i < mpdots; i++)
            {
                Console.Write($".");
            }
            Console.Write($"|"); //end bracket

        }
    }
}
