using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MortalEngines.Entities.Factories
{
    public class PilotFactory : IPilotFactory
    {
        public Pilot CreatePilot(string name)
        {
            var neededType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == "Pilot");
            Pilot newPilot = (Pilot)Activator.CreateInstance(neededType, name);

            return newPilot;
        }
    }
}
