using System;

namespace _02._Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());
            int result = GetMax(one, two, three);
            Console.WriteLine(result);
        }

        private static int GetMax(int one, int two, int three)
        {
            int result = 0;
            if (one > two && one > three)
            {
                result = one;
            }
            else if (two > one && two > three)
            {
                result = two;
            }
            else
            {
                result = three;
            }
            return result;
        }
    }
}
