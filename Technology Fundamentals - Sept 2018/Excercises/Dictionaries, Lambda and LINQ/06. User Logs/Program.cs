using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> userAndIps = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                string[] arr = input.Split(new string[] { " ", "=" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string user = arr[5];
                string ip = arr[1];

                if (userAndIps.ContainsKey(user) == false)
                {
                    userAndIps.Add(user, new Dictionary<string, int>());
                    userAndIps[user].Add(ip, 1);
                }
                else
                {
                    if (userAndIps[user].ContainsKey(ip) == false)
                    {
                        userAndIps[user].Add(ip, 1);
                    }
                    else
                    {
                        userAndIps[user][ip] += 1;
                    }
                }


                input = Console.ReadLine();
            }


            foreach (var user in userAndIps)
            {
                int count = user.Value.Count();
                int i = 0;

                Console.WriteLine($"{user.Key}: ");
                foreach (var kvp2 in user.Value)
                {
                    if (i < count - 1)
                    {
                        Console.Write($"{kvp2.Key} => {kvp2.Value}, ");
                    }
                    else
                    {
                        Console.Write($"{kvp2.Key} => {kvp2.Value}.");
                        Console.WriteLine();

                    }
                    i++;

                }
            }

        }
    }
}
