using System;

namespace _04._Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] arr = new bool[n + 1];
            int p = 2;
            arr[0] = arr[1] = false;
            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = true;
            }

            int counter = 2;

            for (int i = counter * p; p <= n; i += p)
            {
                if (i > n)
                {
                    p++;
                    i = p;
                }
                else
                {
                    arr[i] = false;
                }


            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
