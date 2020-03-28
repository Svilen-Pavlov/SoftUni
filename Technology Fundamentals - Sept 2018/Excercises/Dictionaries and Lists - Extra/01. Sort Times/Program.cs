using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sort_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split().ToArray();
            List<string> times = input.Split().ToList();

            times.Sort();
            Console.WriteLine(string.Join(", ", times));

        }
    }
}
