using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(30, 10);

            string input = Console.ReadLine();
            string[] inputArr = input.Split(':');
            string name = inputArr[0];
            List<string> cardsList = new List<string>();

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while (name != "JOKER")
            {
                cardsList = inputArr[1].Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (dict.ContainsKey(name) == false)
                {

                    dict.Add(name, cardsList.Distinct().ToList());

                }
                else
                {
                    var concatlist = dict[name].Concat(cardsList).Distinct().ToList();
                    dict[name] = concatlist;
                }


                input = Console.ReadLine();
                inputArr = input.Split(':');

                name = inputArr[0];
            } //END OF CARDS INPUT

            foreach (var kvp in dict) // za vseki KVP ot dictionary-to
            {

                int sum = Calculate(kvp.Value);
                Console.WriteLine($"{kvp.Key}: {sum}");

            }
        }

        private static int Calculate(List<string> cardsList)
        {
            int sum = 0;
            cardsList.Distinct();
            foreach (var card in cardsList)
            {
                int currentCardValue = 0;
                int multiplier = 0;
                char[] current = card.ToCharArray();
                switch (current[current.Length - 1])
                {
                    case 'S': multiplier = 4; break;
                    case 'H': multiplier = 3; break;
                    case 'D': multiplier = 2; break;
                    case 'C': multiplier = 1; break;

                }

                if (current.Length == 2)
                {
                    bool ifSuccess = int.TryParse(current[0].ToString(), out int power);
                    if (ifSuccess)
                    {
                        currentCardValue = power * multiplier;
                    }
                    else
                    {
                        switch (current[0])
                        {
                            case 'J': currentCardValue = 11 * multiplier; break;
                            case 'Q': currentCardValue = 12 * multiplier; break;
                            case 'K': currentCardValue = 13 * multiplier; break;
                            case 'A': currentCardValue = 14 * multiplier; break;
                        }
                    }

                }
                else
                {
                    currentCardValue = 10 * multiplier;
                }

                sum += currentCardValue;
            }
            return sum;
        }
    }
}
