using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MortalEngines.Entities.Factories
{
    public class TankFactory : ITankFactory
    {
        public Tank CreateTank(string name, double attack, double defense)
        {
            var neededType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == "Tank");
            Tank newTank = (Tank)Activator.CreateInstance(neededType, name,attack,defense);

            return newTank;
        }
    }
}
