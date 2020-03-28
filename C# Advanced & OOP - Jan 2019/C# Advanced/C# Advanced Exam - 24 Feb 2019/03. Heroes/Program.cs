using System;

namespace Program
{
    public class Program
    {
        public static void Main()
        {

            Item item = new Item(100, 15, 20); //str,abi,int
            Hero hero1 = new Hero("Ivan", 100, item);

            Item item2 = new Item(20, 100, 40); //str,abi,int
            Hero hero2 = new Hero("Georgi", 150, item2);

            Item item3 = new Item(50, 60, 100); //str,abi,int
            Hero hero3 = new Hero("Svilen", 200, item3);

            var repo = new HeroRepository();

            repo.Add(hero1);
            repo.Add(hero2);
            repo.Add(hero3);

            Console.WriteLine(repo.GetHeroWithHighestStrength());
            Console.WriteLine(repo.GetHeroWithHighestAbility());
            Console.WriteLine(repo.GetHeroWithHighestIntelligence());

            Console.WriteLine(repo.Count);
        }
    }
}
