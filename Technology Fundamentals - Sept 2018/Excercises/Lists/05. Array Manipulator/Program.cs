using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            string[] command = input.Split().ToArray();
            string commandword = command[0];

            while (commandword != "print")
            {

                if (commandword == "add")
                {
                    Add(command, list);
                }
                else if (commandword == "addMany")
                {
                    AddMany(command, list);
                }
                else if (commandword == "contains")
                {
                    Contains(command, list);
                }
                else if (commandword == "remove")
                {
                    int index = int.Parse(command[1]);
                    list.RemoveAt(index);
                }
                else if (commandword == "shift")
                {
                    Shift(command, list);
                }
                else if (commandword == "sumPairs")
                {
                    SumPairs(command, list);
                }

                input = Console.ReadLine();
                command = input.Split().ToArray();
                commandword = command[0];
            }
            Console.Write("[");
            Console.Write(string.Join(", ", list));
            Console.Write("]");
        }

        private static void SumPairs(string[] command, List<int> list)
        {
            if (list.Count % 2 == 0)
            {
                for (int i = list.Count - 1; i > 0; i -= 2)
                {
                    list[i - 1] = list[i] + list[i - 1];
                    list.RemoveAt(i);
                }
            }
            else
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i] = list[i] + list[i + 1];
                    list.RemoveAt(i + 1);
                }
            }

        }

        private static void Shift(string[] command, List<int> list)
        {
            int positions = int.Parse(command[1]);
            for (int j = 0; j < positions; j++)
            {
                int temp = list[0];
                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i] = list[i + 1];
                }
                list[list.Count - 1] = temp;
            }
        }

        private static void Contains(string[] command, List<int> list)
        {
            int magic = int.Parse(command[1]);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == magic)
                {
                    Console.WriteLine(i); break;
                }
                if (i == list.Count - 1)
                {
                    Console.WriteLine(-1);
                }
            }
        }

        private static void AddMany(string[] command, List<int> list)
        {
            int index = int.Parse(command[1]);
            int[] parsed = new int[command.Length - 2];
            for (int i = 2; i < command.Length; i++)
            {
                parsed[i - 2] = int.Parse(command[i]);
            }
            list.InsertRange(index, parsed);
        }

        private static void Add(string[] command, List<int> list)
        {
            int index = int.Parse(command[1]);
            int value = int.Parse(command[2]);
            list.Insert(index, value);
        }
    }
}
