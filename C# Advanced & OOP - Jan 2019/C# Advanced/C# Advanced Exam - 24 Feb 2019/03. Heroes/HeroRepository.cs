using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class HeroRepository
    {
        public Dictionary<string,Hero> Collection { get; set; }
        public int Count => Collection.Count;


        public HeroRepository()
        {
            Collection = new Dictionary<string, Hero>();
        }

        public void Add(Hero hero)
        {
            Collection.Add(hero.Name, hero);
        }
        public Hero Remove(string name)
        {
            Hero toReturn=Collection[name];
            Collection.Remove(name);
            return toReturn;
        }
        public Hero GetHeroWithHighestStrength()
        {
            Item testItem = new Item(-1, -1, -1);
            Hero toReturn = new Hero("Test",-1, testItem);
            int max = -1;
            foreach (var hero in Collection)
            {
                if (hero.Value.Item.Strength>max)
                {
                    max = hero.Value.Item.Strength;
                    toReturn = hero.Value;
                }
            }
            return toReturn;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Item testItem = new Item(-1, -1, -1);
            Hero toReturn = new Hero("Test", -1, testItem);
            int max = -1;
            foreach (var hero in Collection)
            {
                if (hero.Value.Item.Ability > max)
                {
                    max = hero.Value.Item.Ability;

                    toReturn = hero.Value;
                }
            }
            return toReturn;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Item testItem = new Item(-1, -1, -1);
            Hero toReturn = new Hero("Test", -1, testItem);
            int max = -1;
            foreach (var hero in Collection)
            {
                if (hero.Value.Item.Intelligence > max)
                {
                    max = hero.Value.Item.Intelligence;
                    toReturn = hero.Value;
                }
            }
            return toReturn;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Collection.Values);
        }
    }
}
