using System;
using System.Linq;

namespace _01._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = 0;
            int maxcount = 0;
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count > maxcount)
                {
                    maxcount = count;
                    index = i;
                }
                count = 0;
            }
            for (int i = index; i < index + maxcount + 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
