using System;

namespace _19._Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long picnum = long.Parse(Console.ReadLine());
            int filtertime = int.Parse(Console.ReadLine());
            double filterfactor = double.Parse(Console.ReadLine());
            long uploadtime = long.Parse(Console.ReadLine());



            double ff = Math.Round(filterfactor, 0, MidpointRounding.AwayFromZero);

            double usefull = (Math.Ceiling(picnum * ff / 100)); //Console.WriteLine(usefull);

            long allfilterseconds = picnum * filtertime; //Console.WriteLine(allfilterseconds);
            long totaluploadseconds = (long)usefull * uploadtime; //Console.WriteLine(totaluploadseconds);
            long totalseconds = allfilterseconds + totaluploadseconds; //Console.WriteLine($"tt secs{totalseconds}");//total time

            long resultdays = totalseconds / 86400;
            long resulthours = totalseconds % 86400 / 3600;
            long resultminutes = totalseconds % 3600 / 60;
            long resultseconds = totalseconds % 60;

            Console.WriteLine($"{resultdays}:{resulthours:d2}:{resultminutes:d2}:{resultseconds:d2}");
        }
    }
}
