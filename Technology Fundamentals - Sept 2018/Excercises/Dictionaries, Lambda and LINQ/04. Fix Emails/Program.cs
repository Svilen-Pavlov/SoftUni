using System;
using System.Collections.Generic;

namespace _04._Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            while (name != "stop")
            {
                string emailWord = Console.ReadLine();
                string[] email = emailWord.Split('@', '.');
                string end = email[2];
                if (dict.ContainsKey(name) == false)
                {
                    if (end != "us" && end != "uk")
                    {
                        dict.Add(name, emailWord);
                    }
                }
                else
                {
                    dict[name] = emailWord;
                }


                name = Console.ReadLine();
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
