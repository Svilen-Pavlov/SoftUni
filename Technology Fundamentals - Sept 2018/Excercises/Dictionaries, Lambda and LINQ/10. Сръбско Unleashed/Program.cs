using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Сръбско_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> Ledger = new Dictionary<string, Dictionary<string, int>>();


            while (input != "End")
            {
                if (Check(input) == true)
                {
                    string[] arr1 = input.Split('@');
                    List<string> singerNamesArr = arr1[0].Split().ToList();
                    string singerName = string.Join(" ", singerNamesArr);
                    List<string> venueAndnumbers = arr1[1].Split().ToList();
                    int countTicket = venueAndnumbers.Count();
                    int ticketCount = int.Parse(venueAndnumbers[countTicket - 1]);
                    int ticketPrice = int.Parse(venueAndnumbers[countTicket - 2]);
                    int profit = ticketCount * ticketPrice;
                    venueAndnumbers.RemoveAt(venueAndnumbers.Count - 1);
                    venueAndnumbers.RemoveAt(venueAndnumbers.Count - 1);
                    string venueName = string.Join(" ", venueAndnumbers);

                    if (Ledger.ContainsKey(venueName) == false) //no venue
                    {
                        Ledger.Add(venueName, new Dictionary<string, int>());
                        Ledger[venueName].Add(singerName, profit);
                    }
                    else
                    {
                        if (Ledger[venueName].ContainsKey(singerName) == false) //no artist
                        {
                            Ledger[venueName].Add(singerName, profit);
                        }
                        else
                        {
                            Ledger[venueName][singerName] += profit;
                        }
                    }
                    input = Console.ReadLine();
                }
                else
                {
                    input = Console.ReadLine();
                }
            }

            foreach (var ledgerEntry in Ledger)
            {
                Console.WriteLine(ledgerEntry.Key);

                foreach (var singerProfit in ledgerEntry.Value.OrderBy(x => -x.Value))
                {
                    Console.WriteLine($"#  {singerProfit.Key}-> {singerProfit.Value}");
                }
            }



        }

        private static bool Check(string input)
        {
            //singer @venue ticketsPrice ticketsCount
            //SKIP THOSE: Ceca@Belgrade125 12378, Ceca @Belgrade12312 123
            bool result = true;
            string[] arr1 = input.Split('@');
            List<string> singerNamesArr = arr1[0].Split().ToList();
            string singerName = string.Join(" ", singerNamesArr);
            List<string> venueAndnumbers = arr1[1].Split().ToList();
            char[] singerChar = singerName.ToCharArray();
            int countTicket = venueAndnumbers.Count();

            if (singerChar[singerChar.Length - 1] != ' ') 
            {
                result = false;
            }
            if (venueAndnumbers.Count < 3) //insufficient tokeni 
            {
                result = false;
            }
            bool mergedDigits = int.TryParse(venueAndnumbers[countTicket - 1], out int ticketCount);
            bool mergedDigits2 = int.TryParse(venueAndnumbers[countTicket - 2], out int ticketPrice);
            if (mergedDigits == false || mergedDigits2 == false)
            {
                result = false;
            }

            return result;
        }
    }
}
