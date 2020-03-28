using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray(); ;
            string commandword = input[0];
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();

            while (commandword != "END")
            {

                if (commandword == "A")
                {
                    string name = input[1];
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
                    string name = input[1];
                    if (dict.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {dict[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
                else if (commandword == "ListAll")
                {
                    foreach (var kvp in dict)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }
                }
                input = Console.ReadLine().Split().ToArray(); ;
                commandword = input[0];
            }
        }
    }
}
