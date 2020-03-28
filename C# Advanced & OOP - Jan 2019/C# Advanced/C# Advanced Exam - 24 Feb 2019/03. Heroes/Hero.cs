﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            return $"Hero: {this.Name} - {Level}lvl" + Environment.NewLine +
                Item.ToString();
        }
    }
}
