using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> list = input.Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split().ToArray();
            string commandword = command[0];
            while (commandword != "Odd" && commandword != "Even")
            {
                if (commandword == "Delete")
                {
                    int element = int.Parse(command[1]);
                    list.RemoveAll(item => item == element);


                }
                else if (commandword == "Insert")
                {
                    int element = int.Parse(command[1]);
                    int position = int.Parse(command[2]);

                    list.Insert(position, element);
                }
                command = Console.ReadLine().Split().ToArray();
                commandword = command[0];
            }

            foreach (var item in list)
            {
                if (commandword == "Even")
                {
                    if (item % 2 == 0)
                    {
                        Console.Write(item + " ");
                    }
                }
                else
                {
                    if (item % 2 != 0)
                    {
                        Console.Write(item + " ");
                    }
                }


            }

        }
    }
}
