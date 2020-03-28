using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Factories.Contracts
{
    public interface IFighterFactory
    {
        Fighter CreateFighter(string name,double attack,double defense);
    }
}
