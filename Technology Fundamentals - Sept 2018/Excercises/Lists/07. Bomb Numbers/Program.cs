using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //current code
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split().ToArray();
            int bomb = int.Parse(input[0]);
            int aoe = int.Parse(input[1]);
            int Lcount = list.Count;
            int sum = 0;
            int bombnow = list.IndexOf(bomb);
            int indexRemoveRight = bombnow + 1;
            int countRemoveRight = aoe;
            int indexRemoveLeft = bombnow - aoe;
            int leftloss = 0;
            int countRemoveLeft = 0;
            while (bombnow != -1)
            {
                indexRemoveRight = bombnow + 1;
                countRemoveRight = aoe;
                indexRemoveLeft = bombnow - aoe;
                leftloss = 0;
                countRemoveLeft = 0;

                if ((countRemoveRight + indexRemoveRight) > list.Count - 1) //dali iRight izliza izvun lista
                {
                    countRemoveRight = list.Count - indexRemoveRight;
                }
                else if ((indexRemoveRight == list.Count)) // ako bombata e poslednoto
                {
                    countRemoveRight = 0;
                }

                // i samata bomba

                if (indexRemoveLeft < 0)
                {
                    indexRemoveLeft = 0;
                    leftloss = Math.Abs(bombnow - aoe);
                }
                countRemoveLeft = (aoe - leftloss) + 1; // +1 e samata bomba

                list.RemoveRange(indexRemoveRight, countRemoveRight);
                list.RemoveRange(indexRemoveLeft, countRemoveLeft); // +samata bomba
                bombnow = list.IndexOf(bomb);
            }




            // Console.WriteLine(string.Join(" ", list));

            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            Console.WriteLine(sum);
        }
    }
}
