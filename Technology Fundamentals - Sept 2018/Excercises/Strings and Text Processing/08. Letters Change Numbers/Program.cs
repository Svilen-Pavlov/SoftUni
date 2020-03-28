using System;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            double sum = 0;

            foreach (var item in input)
            {

                string combo = item;
                char before = combo[0];
                char after = combo[combo.Length - 1];
                combo = combo.Remove(0, 1);
                combo = combo.Remove(combo.Length - 1, 1);
                double num = double.Parse(combo);

                if (before > 64 && before < 91)
                {
                    num /= (before - 64);
                }
                else
                {
                    num *= (before - 96);
                }
                if (after > 64 && after < 91)
                {
                    num -= (after - 64);
                }
                else
                {
                    num += (after - 96);
                }

                sum += num;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
