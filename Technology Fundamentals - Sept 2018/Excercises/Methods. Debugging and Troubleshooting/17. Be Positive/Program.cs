using System;
using System.Collections.Generic;

namespace _17._Be_Positive
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSequences; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');
                var numbers = new List<int>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (!input[j].Equals(string.Empty))
                    {
                        int num = int.Parse(input[j]);
                        numbers.Add(num);
                    }
                }

                bool found = false;

                for (int k = 0; k < numbers.Count; k++)
                {
                    int currentNum = numbers[k];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else
                    {
                        if (k + 1 < numbers.Count)
                        {
                            currentNum += numbers[k + 1];

                            if (currentNum >= 0)
                            {
                                if (found)
                                {
                                    Console.Write(" ");
                                }

                                Console.Write(currentNum);

                                found = true;
                            }
                            k++;
                        }
                        else
                        {
                            break;
                        }

                    }

                }

                if (!found)
                {
                    Console.WriteLine("(empty)");
                }
                else
                {
                    Console.WriteLine();
                }

            }
        }
    }
}
