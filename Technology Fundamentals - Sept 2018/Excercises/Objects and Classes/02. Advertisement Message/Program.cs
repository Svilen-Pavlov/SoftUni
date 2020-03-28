using System;

namespace _02._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                AdMessage first = new AdMessage();
                Console.WriteLine(first.Message);

            }

        }

        class AdMessage
        {
            public string Phrase { get; set; }
            public string Event { get; set; }
            public string Author { get; set; }
            public string City { get; set; }
            public string Message { get; set; }

            public AdMessage()
            {
                string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
                string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
                string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
                string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
                //6,6,8,5
                Random rnd = new Random();
                int index1 = rnd.Next(0, 5);
                int index2 = rnd.Next(0, 5);
                int index3 = rnd.Next(0, 7);
                int index4 = rnd.Next(0, 4);

                this.Phrase = phrases[index1];
                this.Event = events[index2];
                this.Author = authors[index3];
                this.City = cities[index4];
                this.Message = this.Phrase + " " + this.Event + " " + this.Author + " - " + this.City;
            }
        }
    }
}
