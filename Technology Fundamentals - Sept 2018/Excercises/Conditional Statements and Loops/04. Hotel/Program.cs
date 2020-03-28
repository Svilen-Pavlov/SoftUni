using System;

namespace _04._Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioprice = 0;
            double suiteprice = 0;
            double doubleprice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioprice = 50 * nights;
                    doubleprice = 65 * nights;
                    suiteprice = 75 * nights;
                    break;
                case "June":
                case "September":
                    studioprice = 60 * nights;
                    doubleprice = 72 * nights;
                    suiteprice = 82 * nights;
                    break;
                case "July":
                case "August":
                case "December":
                    studioprice = 68 * nights;
                    doubleprice = 77 * nights;
                    suiteprice = 89 * nights;
                    break;
            }

            if ((month == "June" || month == "September") && nights > 14)
            {
                doubleprice *= 0.9;
            }
            if ((month == "July" || month == "August" || month == "December") && nights > 14)
            {
                suiteprice *= 0.85;
            }
            if (month == "October" && nights > 7)
            {
                studioprice = 50 * (nights - 1);
            }
            if (month == "September" && nights > 7)
            {
                studioprice = 60 * (nights - 1);
            }
            if ((month == "May" || month == "October") && nights > 7)
            {
                studioprice *= 0.95;
            }




            Console.WriteLine($"Studio: {studioprice:f2} lv.");
            Console.WriteLine($"Double: {doubleprice:f2} lv.");
            Console.WriteLine($"Suite: {suiteprice:f2} lv.");
        }
    }
}
