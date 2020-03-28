namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Factories;
    using MortalEngines.Entities.Factories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IPilotFactory pilotFactory;
        private ITankFactory tankFactory;
        private IFighterFactory fighterFactory;

        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;

        public MachinesManager()
        {
            this.pilotFactory = new PilotFactory();
            this.tankFactory = new TankFactory();
            this.fighterFactory = new FighterFactory();

            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public string HirePilot(string name)
        {
            string result = string.Empty;
            if (pilots.ContainsKey(name))
            {
                result = $"Pilot {name} is hired already";
            }
            else
            {
                Pilot newPilot = pilotFactory.CreatePilot(name);
                pilots.Add(name, newPilot);
                result = $"Pilot {name} hired";
            }
            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            string result = string.Empty;

            IPilot currPilot = pilots.First(x => x.Key == pilotReporting).Value;
            result = currPilot.Report();

            return result;
        }

        public string MachineReport(string machineName)
        {
            IMachine currMachine = this.machines.First(x => x.Key == machineName).Value;

            return currMachine.ToString();
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            string result = string.Empty;
            if (machines.ContainsKey(name))
            {
                result = $"Machine {name} is manufactured already";
            }
            else
            {
                Tank newTank = tankFactory.CreateTank(name, attackPoints, defensePoints);

                machines.Add(name, newTank);
                result = $"Tank {newTank.Name} manufactured - attack: {newTank.AttackPoints:f2}; defense: {newTank.DefensePoints:f2}";
            }
            return result;
        }

        

        public string ToggleTankDefenseMode(string tankName)
        {
            string result = string.Empty;
            if (machines.ContainsKey(tankName) == false)
            {
                result = $"Machine {tankName} could not be found";
            }
            else
            {
                Tank currTank = (Tank)machines[tankName];
                currTank.ToggleDefenseMode();
                machines[tankName] = currTank;
                result = $"Tank {tankName} toggled defense mode";
            }
            //SCETCHY
            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            string result = string.Empty;
            if (machines.ContainsKey(name))
            {
                result = $"Machine {name} is manufactured already";
            }
            else
            {
                Fighter newFighter = fighterFactory.CreateFighter(name, attackPoints, defensePoints);

                machines.Add(name, newFighter);
                result = $"Fighter {newFighter.Name} manufactured - attack: {newFighter.AttackPoints:f2}; defense: {newFighter.DefensePoints:f2}; aggressive: ON";
            }
            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            string result = string.Empty;
            if (machines.ContainsKey(fighterName) == false)
            {
                result = $"Machine {fighterName} could not be found";
            }
            else
            {
                Fighter currFighter = (Fighter)machines[fighterName];
                currFighter.ToggleAggressiveMode();
                machines[fighterName] = currFighter;

                result = $"Fighter {fighterName} toggled aggressive mode";
            }
            //SCETCHY
            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            string result = string.Empty;

            if (this.pilots.ContainsKey(selectedPilotName) == false)
            {
                result = $"Pilot {selectedPilotName} could not be found";
            }

            else if (this.machines.ContainsKey(selectedMachineName) == false)
            {
                result = $"Machine {selectedMachineName} could not be found";
            }

            else if ((machines[selectedMachineName].Pilot == null) == false)
            {
                result = $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                this.pilots[selectedPilotName].AddMachine(this.machines[selectedMachineName]);
                this.machines[selectedMachineName].Pilot = this.pilots[selectedPilotName];
                result = $"Pilot {this.pilots[selectedPilotName].Name} engaged machine {this.machines[selectedMachineName].Name}";
            }
            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            string result = string.Empty;
            //exist
            if (machines.ContainsKey(attackingMachineName)==false)
            {
                result=$"Machine {attackingMachineName} could not be found";
            }
            else if (machines.ContainsKey(defendingMachineName) == false)
            {
                result = $"Machine {defendingMachineName} could not be found";
            }
            //health
            else if (machines[attackingMachineName].HealthPoints<=0)
            {
                result = $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if(machines[defendingMachineName].HealthPoints <= 0)
            {
                result = $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            else
            {
                machines[attackingMachineName].Attack(machines[defendingMachineName]);
                result = $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {machines[defendingMachineName].HealthPoints:f2}";
            }
            return result;
        }








    }
}