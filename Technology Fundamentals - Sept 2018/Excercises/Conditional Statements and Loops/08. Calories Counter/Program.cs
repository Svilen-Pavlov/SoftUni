using System;

namespace _08._Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            string input1 = "";
            int calories = 0;
            for (int i = 0; i < n; i++)
            {

                input1 = Console.ReadLine();
                input = input1.ToLower();
                if (input == "cheese")
                {
                    calories += 500;
                }
                if (input == "tomato sauce")
                {
                    calories += 150;
                }
                if (input == "salami")
                {
                    calories += 600;
                }
                if (input == "pepper")
                {
                    calories += 50;
                }
            }

            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
