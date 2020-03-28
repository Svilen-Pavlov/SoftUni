using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const int initialHealthPoints = 200;
        private bool aggresiveMode;
        private const int attChange = 50;
        private const int defChange = 25;

        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.aggresiveMode = true;
            this.AttackPoints += attChange;
            this.DefensePoints -= defChange;
        }

        public bool AggressiveMode
        {
            get => this.aggresiveMode;
            private set
            {
                this.aggresiveMode = value;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= attChange;
                this.DefensePoints += defChange;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += attChange;
                this.DefensePoints -= defChange;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            string mode = this.AggressiveMode ? "ON" : "OFF";

            sb.AppendLine(Environment.NewLine + $" *Aggressive: {mode}");

            return sb.ToString().TrimEnd();
        }
    }
}
