using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            Dictionary<string, List<Player>> ledger = new Dictionary<string, List<Player>>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                Player curPlayer = new Player(input);

                if (ledger.ContainsKey(curPlayer.Team))
                {
                    Console.WriteLine($"Team {curPlayer.Team} was already created!");
                    continue;
                }

                bool uni = true;
                foreach (var list in ledger.Values) // 1.creator exists alrdy? 2. existing player?
                {
                    foreach (var player in list)
                    {
                        if (player.Name == curPlayer.Name)
                        {
                            uni = false;
                            Console.WriteLine($"Member {player.Name} cannot create another team.");
                            break;
                        }
                    }
                }
                if (uni == true)
                {
                    ledger.Add(curPlayer.Team, new List<Player>());
                    ledger[curPlayer.Team].Add(curPlayer);
                    Console.WriteLine($"Team {curPlayer.Team} has been created by {curPlayer.Name}!");
                }
            }

            input = Console.ReadLine(); // START secondpart
            while (input != "end of assignment")
            {
                bool uni = true;
                Player curPlayer = new Player(input);

                if (ledger.ContainsKey(curPlayer.Team) == false)
                {
                    Console.WriteLine($"Team {curPlayer.Team} does not exist!");
                    input = Console.ReadLine(); // START secondpart
                    continue;
                }

                foreach (var list in ledger.Values) // 1.creator exists alrdy? 2. existing player?
                {
                    foreach (var player in list)
                    {
                        if (player.Name == curPlayer.Name)
                        {
                            Console.WriteLine($"Member {curPlayer.Name} cannot join team {curPlayer.Team}!");
                            uni = false;
                        }
                    }
                }
                if (uni)
                {
                    ledger[curPlayer.Team].Add(curPlayer);
                }
                input = Console.ReadLine();//renew
            }
            //normal print
            foreach (var kvp in ledger.OrderBy(x => x.Key).Where(x => x.Value.Count > 1))
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($"- {kvp.Value[0].Name}");
                foreach (var member in kvp.Value.Skip(1))
                {
                    Console.WriteLine($"-- {member.Name}");

                }
            }


            //disband print
            Console.WriteLine($"Teams to disband:");
            foreach (var kvp in ledger.OrderBy(x => x.Key))
            {
                if (kvp.Value.Count == 1 && kvp.Value[0].Role == "leader")
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }

    class Player
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Team { get; set; }

        public Player(string s)
        {
            string[] arr = s.Split('-');
            this.Name = arr[0];
            if (arr[1][0] == '>')
            {
                string teamName = arr[1].Remove(0, 1);
                this.Team = teamName;
                this.Role = "member";
            }
            else
            {
                this.Team = arr[1];
                this.Role = "leader";
            }
        }
    }
}
