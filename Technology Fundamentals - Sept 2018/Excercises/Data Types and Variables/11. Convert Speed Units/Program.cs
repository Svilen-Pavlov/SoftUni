using System;

namespace _11._Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            float meters = float.Parse(Console.ReadLine());
            int ihours = int.Parse(Console.ReadLine());
            int iminutes = int.Parse(Console.ReadLine());
            int iseconds = int.Parse(Console.ReadLine());
            //1609m=mile
            float seconds = ihours * 3600 + iminutes * 60 + iseconds;
            float miles = meters / 1609;
            float mps = meters / seconds;
            float hours = seconds / 3600;
            float kph = (float)(meters / 1000) / hours;
            float miph = miles / hours;
            Console.WriteLine($"{mps}"); //mps
            Console.WriteLine($"{kph}"); //kph
            Console.WriteLine($"{miph}"); //mph
        }
    }
}
