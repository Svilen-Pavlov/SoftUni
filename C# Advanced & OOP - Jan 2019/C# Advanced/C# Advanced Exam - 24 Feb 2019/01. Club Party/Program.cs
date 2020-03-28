using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Stack<string> inputStack = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            Queue<Hall> halls = new Queue<Hall>();

            Hall currHall = new Hall();
            foreach (var item in inputStack)
            {
                if (int.TryParse(item, out int useless) == false)
                {
                    Hall newHall = new Hall(item);
                    halls.Enqueue(newHall);
                }
                else
                {
                    if (halls.Count == 0) continue;
                    else
                    {
                        currHall = halls.Peek();
                        int currGroup = int.Parse(item);

                        if (currGroup + currHall.Total <= size)
                        {
                            currHall.AddGroup(currGroup);
                        }
                        else
                        {
                            Console.WriteLine($"{currHall.Name} -> {string.Join(", ", currHall.Groups)}");
                            halls.Dequeue();
                            if (halls.Count == 0) continue;
                            else
                            {
                                currHall = halls.Peek();
                                currHall.AddGroup(currGroup);
                            }
                        }
                    }
                }
            }
        }
        public class Hall
        {
            public string Name { get; set; }
            public int Total { get; set; } = 0;
            public List<int> Groups { get; set; } = new List<int>();

            public Hall()
            { }

            public Hall(string name)
            {
                Name = name;
            }

            public void AddGroup(int group)
            {
                Total += group;
                Groups.Add(group);
            }
        }
    }
}
