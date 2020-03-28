using System;
using System.Collections.Generic;

namespace _03._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();


            Dictionary<string, long> dict = new Dictionary<string, long>();

            while (inputString != "stop")
            {
                long inputValue = long.Parse(Console.ReadLine());
                if (dict.ContainsKey(inputString))
                {
                    dict[inputString] += inputValue;
                }
                else
                {
                    dict.Add(inputString, inputValue);
                }
                inputString = Console.ReadLine();

            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
