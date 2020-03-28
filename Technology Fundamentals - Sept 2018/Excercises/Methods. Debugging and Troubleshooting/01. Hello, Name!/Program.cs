using System;

namespace _01._Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Print(name);
        }

        private static void Print(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
