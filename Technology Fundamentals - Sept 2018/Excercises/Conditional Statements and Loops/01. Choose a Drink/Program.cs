using System;

namespace _01._Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            string job = Console.ReadLine();
            switch (job)
            {
                case "Athlete": job = "Water"; break;
                case "Businesswoman":
                case "Businessman": job = "Coffee"; break;
                case "SoftUni Student": job = "Beer"; break;
                default:
                    job = "Tea";
                    break;
            }
            Console.WriteLine(job);
        }
    }
}
