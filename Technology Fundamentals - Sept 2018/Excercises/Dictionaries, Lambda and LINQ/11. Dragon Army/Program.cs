using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, int[]>> Ledger = new Dictionary<string, SortedDictionary<string, int[]>>();
            Dictionary<string, double[]> typeStats = new Dictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArr = input.Split().ToArray();
                int[] stats = new int[3];
                double[] stats2 = new double[3];
                string type = inputArr[0];
                string name = inputArr[1];
                //populating stats
                for (int j = 0; j < 3; j++)
                {
                    int value = CheckforNull(inputArr[j + 2], j);
                    stats[j] = value;
                    stats2[j] = value;
                }


                //populating dictionaries
                if (Ledger.ContainsKey(type) == false) //no type
                {
                    Ledger.Add(type, new SortedDictionary<string, int[]>());
                    Ledger[type].Add(name, stats);

                    typeStats.Add(type, stats2);
                }
                else
                {
                    if (Ledger[type].ContainsKey(name) == false) //no ime
                    {
                        Ledger[type].Add(name, stats);
                    }
                    else
                    {
                        Ledger[type][name] = stats;
                    }
                }
                //avg values
            }

            Dictionary<string, double[]> typeAvg = new Dictionary<string, double[]>();


            foreach (var typeNameStats in Ledger)
            {
                string type = typeNameStats.Key;
                double sumDMG = 0;
                double sumHP = 0;
                double sumARM = 0;
                int count = typeNameStats.Value.Values.Count();

                foreach (var NameStats in typeNameStats.Value) // -names/stats
                {

                    string name = NameStats.Key;
                    int[] currentStats = NameStats.Value;
                    //1 {damage}  2 {health} 3 {armor}
                    sumDMG += currentStats[0];
                    sumHP += currentStats[1];
                    sumARM += currentStats[2];


                }
                double avgDMG = sumDMG / count;
                double avgHP = sumHP / count;
                double avgARM = sumARM / count;
                double[] AdditiveArr = new double[] { avgDMG, avgHP, avgARM };
                typeAvg.Add(type, AdditiveArr);

            }
            //populated avg type

            foreach (var typeNameStats in Ledger)
            {
                string type = typeNameStats.Key;
                double avgDMG = typeAvg[type][0];
                double avgHP = typeAvg[type][1];
                double avgARM = typeAvg[type][2];
                Console.WriteLine($"{type}::({avgDMG:f2}/{avgHP:f2}/{avgARM:f2})");

                foreach (var NameStats in typeNameStats.Value)
                {
                    //-Bazgargal -> damage: 100, health: 2500, armor: 25
                    string name = NameStats.Key;
                    int dmg = NameStats.Value[0];
                    int hp = NameStats.Value[1];
                    int arm = NameStats.Value[2];
                    Console.WriteLine($"-{name} -> damage: {dmg}, health: {hp}, armor: {arm}");
                }


            }

        }


        private static int CheckforNull(string v, int j)
        {
            //{type} {name}        1 {damage}  2 {health} 3 {armor}
            //                  damage 45, health 250, armor 10
            bool isInt = int.TryParse(v, out int result);
            if (isInt == false)
            {
                switch (j + 1)
                {
                    case 1: result = 45; break;
                    case 2: result = 250; break;
                    case 3: result = 10; break;
                }
            }

            return result;
        }
    }
}
