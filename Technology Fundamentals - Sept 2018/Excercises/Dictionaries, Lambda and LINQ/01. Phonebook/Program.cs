using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray(); ;
            string commandword = input[0];
            Dictionary<string, string> dict = new Dictionary<string, string>();

            while (commandword != "END")
            {
                string name = input[1];
                if (commandword == "A")
                {

                    string phone = input[2];
                    if (dict.ContainsKey(name))
                    {
                        dict[name] = phone;
                    }
                    else
                    {
                        dict.Add(name, phone);
                    }


                }
                else if (commandword == "S")
                {
                    if (dict.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {dict[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
                input = Console.ReadLine().Split().ToArray(); ;
                commandword = input[0];
            }

        }
    }
}
