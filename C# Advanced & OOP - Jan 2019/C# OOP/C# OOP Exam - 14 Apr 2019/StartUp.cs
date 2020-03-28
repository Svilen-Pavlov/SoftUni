using MortalEngines.Core;
using MortalEngines.Entities;
using System;
using System.Linq;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {//struct 2:46 - 

            var manager = new MachinesManager();

            //var machine = new Fighter("fighter", 1, 1);
           // manager.HirePilot("Dave");
            //manager.ManufactureFighter("", 1, 1);
            string input = Console.ReadLine();


            while (input != "Quit")
            {
                string toPrint = string.Empty;
                try
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string commandType = tokens[0];
                    string[] args = tokens.Skip(1).ToArray();
                    string name1 = args[0];

                    switch (commandType)
                    {
                        case "HirePilot":
                            toPrint = manager.HirePilot(name1);
                            break;

                        case "PilotReport":
                            toPrint = manager.PilotReport(name1);
                            break;

                        case "ManufactureTank":
                            double attack = double.Parse(args[1]);
                            double defense = double.Parse(args[2]);
                            toPrint = manager.ManufactureTank(name1, attack, defense);
                            break;

                        case "ManufactureFighter":
                            attack = double.Parse(args[1]);
                            defense = double.Parse(args[2]);
                            toPrint = manager.ManufactureFighter(name1, attack, defense);
                            break;

                        case "MachineReport":
                            toPrint = manager.MachineReport(name1);
                            break;

                        case "AggressiveMode":
                            toPrint = manager.ToggleFighterAggressiveMode(name1);
                            break;

                        case "DefenseMode":
                            toPrint = manager.ToggleTankDefenseMode(name1);
                            break;

                        case "Engage":
                            string machineName = args[1];
                            toPrint = manager.EngageMachine(name1, machineName);
                            break;

                        case "Attack":
                            string attacker = name1;
                            string defender = args[1];
                            toPrint = manager.AttackMachines(attacker, defender);
                            break;
                    }
                }
                catch (Exception e)
                {
                    toPrint = $"Error:"+e.Message;
                }
                Console.WriteLine(toPrint);

                input = Console.ReadLine();
            }
        }

    }
}
