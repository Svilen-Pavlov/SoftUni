using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> list = input.Split().Select(int.Parse).ToList();

           
            list.RemoveAll(x => x % 2 != 0);

            double avg = list.Average();


            for (int i = 0; i < list.Count; i++)
            {

                if (list[i] <= avg)
                {
                    list[i]--;
                }
                else
                {
                    list[i]++;
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
