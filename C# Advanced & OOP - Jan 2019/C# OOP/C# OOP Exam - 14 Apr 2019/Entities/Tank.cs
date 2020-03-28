using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine,ITank
    {
        private const int initialHealthPoints = 100;
        private bool defenseMode;
        private const int attChange = 40;
        private const int defChange = 30;

        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.defenseMode = true;
            this.AttackPoints -= attChange;
            this.DefensePoints += defChange;
        }

        public bool DefenseMode
        {
            get => this.defenseMode;
            private set
            {
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += attChange;
                this.DefensePoints -= defChange;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= attChange;
                this.DefensePoints += defChange;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            string mode = this.DefenseMode ? "ON" : "OFF";

            sb.AppendLine(Environment.NewLine + $" *Defense: {mode}");

            return sb.ToString().TrimEnd();
        }

    }
}
