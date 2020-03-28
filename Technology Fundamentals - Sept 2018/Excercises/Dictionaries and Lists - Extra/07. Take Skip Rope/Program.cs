using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> nums = new List<int>();
            List<char> chars = new List<char>();
            List<int> taking = new List<int>();
            List<int> skipping = new List<int>();
            List<string> result = new List<string>();

            foreach (var cha in input)
            {
                if (int.TryParse(cha.ToString(), out int number))
                {
                    nums.Add(number);
                }
                else
                {
                    {
                        chars.Add(cha);
                    }
                }
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if (i % 2 == 0)
                {
                    taking.Add(nums[i]);
                }
                else
                {
                    skipping.Add(nums[i]);
                }
            }

            int numToTake;
            int numToSkip;

            for (int i = 0; i < taking.Count; i++) // PURVO TAKE, POSLE SKIP!
            {
                numToTake = taking[i];
                numToSkip = skipping[i];
                var temp = chars.Take(numToTake);
                string toadd = string.Join("", temp);
                result.Add(toadd);
                int remove = numToTake + numToSkip;
                if (remove > chars.Count())
                {
                    remove = chars.Count();
                    chars.RemoveRange(0, remove);
                    break;
                }
                else
                {
                    chars.RemoveRange(0, remove);
                }
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
