using System;

namespace _04._Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());
            double volfactor = volume / 100;
            //Console.WriteLine(volfactor);

            double energy = volfactor * double.Parse(Console.ReadLine());
            double sugar = volfactor * double.Parse(Console.ReadLine());

            Console.WriteLine($"{volume}ml {name}:\r\n{energy}kcal, {sugar}g sugars");
        }
    }
}
