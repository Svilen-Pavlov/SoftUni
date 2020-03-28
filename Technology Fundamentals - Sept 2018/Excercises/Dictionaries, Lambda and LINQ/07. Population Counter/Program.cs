using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //Sofia|Bulgaria|1000000

            Dictionary<string, Dictionary<string, long>> bigDic = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> countryANDtotalpop = new Dictionary<string, long>();

            while (input != "report")
            {
                string[] arr = input.Split("|");
                string country = arr[1];
                string city = arr[0];
                long population = long.Parse(arr[2]);

                if (bigDic.ContainsKey(country) == false) // new country
                {
                    bigDic.Add(country, new Dictionary<string, long>());
                    countryANDtotalpop.Add(country, population);
                    bigDic[country].Add(city, population);
                }
                else
                {
                    if (bigDic[country].ContainsKey(city) == false) //new city
                    {
                        bigDic[country].Add(city, population);
                        countryANDtotalpop[country] += population;
                    }
                }

                input = Console.ReadLine();
            } //end of input

            var CAPordered = countryANDtotalpop.OrderBy(x => -x.Value);
            //order countries: totalpop(descending)
            //order cities: totalpop(descending)

            foreach (var kvp in countryANDtotalpop.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} (total population: {kvp.Value})");

                foreach (var citypop in bigDic[kvp.Key].OrderBy(x => -x.Value))

                {
                    Console.WriteLine($"=>{citypop.Key}: {citypop.Value}");
                }

            }



        }
    }
}
