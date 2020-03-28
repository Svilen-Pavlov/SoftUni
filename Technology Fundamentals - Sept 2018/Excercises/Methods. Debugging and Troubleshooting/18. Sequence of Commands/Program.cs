using System;
using System.Linq;

namespace _18._Sequence_of_Commands
{
    class Program
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()

        {
            int sizeOfArray = int.Parse(Console.ReadLine());
            string[] FinalArray = new string[10];
            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine().ToLower();
            int counter = 0;
            string line = "";
            while (!command.Equals("stop"))
            {

                if (command == "stop")
                {
                    break;
                }
                string commandword = "";
                int index = command.IndexOf(" ");

                if (index > 0)
                {
                    commandword = command.Substring(0, index);
                }
                else
                {
                    commandword = command;
                }

                int[] args = new int[2];

                if (commandword.Equals("add") ||
                    commandword.Equals("subtract") ||
                    commandword.Equals("multiply"))
                {
                    string[] stringParams = command.Split(ArgumentsDelimiter);
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);

                    long[] result = PerformAction(array, commandword, args);
                    array = result.Clone() as long[];
                }
                else if (commandword.Equals("rshift"))
                {
                    ArrayShiftRight(array);
                }
                else if (commandword.Equals("lshift"))
                {
                    ArrayShiftLeft(array);
                }


                //array e gotov. trqa da go savevame
                for (int i = 0; i < array.Length; i++)
                {
                    line += $"{array[i]}";
                    if (i != array.Length - 1)
                    {
                        line += " ";
                    }
                }
                FinalArray[counter] = line;
                line = "";


                command = Console.ReadLine();

                counter++;

            }
            PrintArray(FinalArray);
        }

        static long[] PerformAction(long[] arr, string action, int[] args)
        {
            long[] array = arr.Clone() as long[];
            int pos = args[0] - 1;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
            return array;

        }

        private static void ArrayShiftRight(long[] arr)
        {
            long temp = 0;

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                if (i == arr.Length - 1)
                {
                    temp = arr[i];
                }
                arr[i] = arr[i - 1];
            }
            arr[0] = temp;
        }

        private static void ArrayShiftLeft(long[] arr)
        {
            long temp = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = temp;
        }
        private static string[] ConvertToString(long[] arr)
        {
            long[] array = arr.Clone() as long[];
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " "); //save
            }
            string[] endArray = array.Clone() as string[];
            return endArray;
        }

        private static void PrintArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Console.WriteLine();
            }

        }
    }
}
