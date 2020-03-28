using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int newcoll = arr[0];
            int index = newcoll;
            int substract = arr[1];
            int magic = arr[2];
            bool found = false;
            list.RemoveRange(index, list.Count - index);
            // Console.WriteLine(string.Join(" ",list));
            for (int i = substract - 1; i >= 0; i--)
            {
                list.RemoveAt(i);

            }
            foreach (var item in list)
            {
                if (item == magic)
                {
                    found = true; break;
                }
            }
            if (found == true)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
