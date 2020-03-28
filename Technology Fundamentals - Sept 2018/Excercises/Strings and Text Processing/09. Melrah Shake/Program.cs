using System;

namespace _09._Melrah_Shake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {

                int indexToRemove = pattern.Length / 2;
                int len = pattern.Length;
                int firstInd = input.IndexOf(pattern);
                int lastInd = input.LastIndexOf(pattern);
                if (firstInd != lastInd && pattern.Length > 0)
                {
                    input = input.Remove(lastInd, len);
                    input = input.Remove(firstInd, len);
                    pattern = pattern.Remove(indexToRemove, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    break;
                }


            }


        }
    }
}
