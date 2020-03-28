using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, int>> bigDic = new SortedDictionary<string, SortedDictionary<string, int>>();

            List<string> usersList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] arr = input.Split();
                string ip = arr[0];
                string user = arr[1];
                int duration = int.Parse(arr[2]);

                if (bigDic.ContainsKey(user) == false) //new user
                {
                    bigDic.Add(user, new SortedDictionary<string, int>());
                    bigDic[user].Add(ip, duration);
                    usersList.Add(user);
                }
                else                                //old user
                {
                    if (bigDic[user].ContainsKey(ip) == false) // new ip
                    {
                        bigDic[user].Add(ip, duration);
                    }
                    else                                       //old ip
                    {
                        bigDic[user][ip] += duration;
                    }
                }
            }

            SortedDictionary<string, int> userDuration = new SortedDictionary<string, int>();

            foreach (var kvp in bigDic)
            {
                int totaldur = 0;

                foreach (var kvp2 in kvp.Value)
                {
                    totaldur += kvp2.Value;
                }
                userDuration.Add(kvp.Key, totaldur);

            } // we have total dur in userDuration

            usersList.Sort();
            for (int i = 0; i < usersList.Count; i++)
            {
                string currUser = usersList[i];
                int count = bigDic[currUser].Count();
                int dur = userDuration[currUser];
                Console.Write($"{currUser}: {dur} ");

                foreach (var ipsAndDurations in bigDic[currUser])
                {
                    int ipcount = bigDic[currUser].Count();
                    if (ipcount == 1)
                    {
                        Console.Write($"[{ipsAndDurations.Key}]"); //      only1
                    }

                    else if (count == bigDic[currUser].Count())
                    {
                        Console.Write($"[{ipsAndDurations.Key},"); //      FIRST
                    }
                    else if (count == 1)
                    {
                        Console.Write($"{ipsAndDurations.Key}]"); //       LAST
                    }
                    else
                    {
                        Console.Write($"{ipsAndDurations.Key},");//        MID
                    }
                    count--;
                    if (count != 0)
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }

        }
    }
}
