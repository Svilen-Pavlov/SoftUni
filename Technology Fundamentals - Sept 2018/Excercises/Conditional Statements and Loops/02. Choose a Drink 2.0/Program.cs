using System;

namespace _02._Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double amm = double.Parse(Console.ReadLine());
            string job;
            switch (input)
            {
                case "Athlete": job = "Water"; amm = 0.7 * amm; break;
                case "Businesswoman":
                case "Businessman": job = "Coffee"; amm = amm; break;
                case "SoftUni Student": job = "Beer"; amm = amm * 1.7; break;
                default:
                    job = "Tea"; amm = amm * 1.2;
                    break;
            }
            Console.WriteLine($"The {input} has to pay {amm:f2}.");

        }
    }
}
