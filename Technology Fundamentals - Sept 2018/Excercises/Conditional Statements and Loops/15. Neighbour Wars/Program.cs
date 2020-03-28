using System;

namespace _15._Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshodmg = int.Parse(Console.ReadLine()); //“Roundhouse kick”  odd turns
            int goshodmg = int.Parse(Console.ReadLine()); //“Thunderous fist” even turns
            int php = 100;
            int ghealth = 100;
            int count = 0;
            string winner = "";
            for (int i = 1; i < 1000000; i++)
            {
                count++;
                if (i % 2 == 0) //first guy kicks
                {
                    php -= goshodmg;
                    if (php <= 0 || ghealth <= 0)
                    {
                        if (php <= 0)
                        {
                            winner = "Gosho";
                        }
                        else
                        {
                            winner = "Pesho";
                        }
                        Console.WriteLine($"{winner} won in {count}th round."); return;
                    }


                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {php} health.");
                }


                else //second guy kicks
                {

                    ghealth -= peshodmg;
                    if (php <= 0 || ghealth <= 0)
                    {
                        if (php <= 0)
                        {
                            winner = "Gosho";
                        }
                        else
                        {
                            winner = "Pesho";
                        }
                        Console.WriteLine($"{winner} won in {count}th round."); return;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {ghealth} health.");
                }

                if (i % 3 == 0)
                {
                    php += 10; ghealth += 10;
                }

            }
        }
    }
}
