using System;
using System.Collections.Generic;

namespace _03._Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            int maxhealth = health;
            string input = Console.ReadLine();
            bool defeat = false;
            List<string> database = new List<string>();
            while (input != "end")
            {

                char[] name = input.ToCharArray();
                int len = name.Length;
                int currentVpower = 0;
                foreach (var cha in name)
                {
                    currentVpower += (int)cha;
                }
                currentVpower /= 3;
                int secondsToDefeat = currentVpower * len;
                if (database.Contains(input))
                {
                    secondsToDefeat /= 3;
                }
                else
                {
                    database.Add(input);
                }

                if (secondsToDefeat > health == false)
                {
                    health -= secondsToDefeat;

                    Console.WriteLine($"Virus {input}: {currentVpower} => {secondsToDefeat} seconds");
                    Console.WriteLine($"{input} defeated in {secondsToDefeat / 60}m {secondsToDefeat % 60}s.");
                    Console.WriteLine($"Remaining health: {health}");
                    double currHP = health * 1.2;
                    health = (int)currHP;
                    if (health > maxhealth)
                    {
                        health = maxhealth;
                    }
                }
                else
                {
                    Console.WriteLine($"Virus {input}: {currentVpower} => {secondsToDefeat} seconds");
                    Console.WriteLine("Immune System Defeated.");
                    defeat = true;
                    break;

                }
                input = Console.ReadLine();
            }
            if (defeat == false)
            {
                Console.WriteLine($"Final Health: {health}");
            }

        }
    }
}
