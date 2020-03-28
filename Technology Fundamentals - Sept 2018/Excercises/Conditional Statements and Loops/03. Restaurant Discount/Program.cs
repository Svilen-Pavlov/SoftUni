using System;

namespace _03._Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string packageInput = Console.ReadLine();
            int price = 0;
            string hallname = "s";
            double cost = 0;
            if (num < 51 && num > 0)
            {
                price = 2500; hallname = "Small Hall";
            }
            else if (num < 101 && num > 0)
            {
                price = 5000; hallname = "Terrace";
            }
            else if (num < 121 && num > 0)
            {

                price = 7500; hallname = "Great Hall";
            }

            switch (packageInput)
            {
                case "Normal": cost = ((price + 500) * 0.95) / num; break;
                case "Gold": cost = ((price + 750) * 0.9) / num; break;
                case "Platinum": cost = ((price + 1000) * 0.85) / num; break;
                default:
                    break;
            }

            if (price != 0)
            {
                Console.WriteLine($"We can offer you the {hallname}");
                Console.WriteLine($"The price per person is {cost:f2}$");
            }
            else { Console.WriteLine("We do not have an appropriate hall."); }
        }
    }
}
