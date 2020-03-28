using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            SortedDictionary<string, int> keyMats = new SortedDictionary<string, int>() { { "shards", 0 }, { "motes", 0 }, { "fragments", 0 } };
            SortedDictionary<string, int> Junk = new SortedDictionary<string, int>();

            string legendary = "";

            while (true)
            {
                string[] arr = input.Split().ToArray();
                int quantity = 0;
                string material = "";
                List<string> mats = new List<string>();
                List<int> qty = new List<int>();
                for (int i = 0; i < arr.Length; i += 2)
                {
                    quantity = int.Parse(arr[i]);
                    material = arr[i + 1];

                    if (material == "fragments" || material == "shards" || material == "motes")
                    {
                        keyMats[material] += quantity;
                        legendary = LegendaryCheck(keyMats);
                        if (legendary != "")
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (Junk.ContainsKey(material) == false) //no such material
                        {
                            Junk.Add(material, quantity);
                        }
                        else
                        {
                            Junk[material] += quantity;
                        }
                    }


                }

                if (legendary != "")
                {
                    break;
                }
                else
                {
                    input = Console.ReadLine().ToLower();
                }

            }

            switch (legendary)
            {
                case "Shadowmourne": keyMats["shards"] -= 250; break;
                case "Dragonwrath": keyMats["motes"] -= 250; break;
                case "Valanyr": keyMats["fragments"] -= 250; break;
            }


            Console.WriteLine(legendary + " obtained!");

            foreach (var kvp in keyMats.OrderBy(x => -x.Value)) //MATS
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in Junk) //JUNK
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static string LegendaryCheck(SortedDictionary<string, int> keyMats)
        {

            string legendary = "";
            foreach (var kvp in keyMats)
            {
                if (kvp.Value >= 250)
                {
                    if (kvp.Key == "shards")
                    {
                        legendary = "Shadowmourne";
                    }
                    else if (kvp.Key == "motes")
                    {
                        legendary = "Dragonwrath";
                    }
                    else
                    {
                        legendary = "Valanyr";
                    }
                }
            }
            return legendary;
        }
    }
}
