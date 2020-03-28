using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05._Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Library Alexandria = new Library();
            for (int i = 0; i < n; i++)
            {
                Book currBook = new Book(Console.ReadLine());
                Alexandria.BookList.Add(currBook);
            }
            Alexandria.Print();
        }
    }

    class Library
    {
        public List<Book> BookList { get; set; }
        public Library()
        {
            List<Book> list = new List<Book>();
            this.BookList = list;
        }
        public void Print()
        {
            Dictionary<string, double> Sales = new Dictionary<string, double>();
            foreach (var entry in BookList)
            {
                if (Sales.ContainsKey(entry.Author) == false)
                {
                    Sales.Add(entry.Author, entry.Price);
                }
                else
                {
                    Sales[entry.Author] += entry.Price;
                }
            }

            foreach (var kvp in Sales.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }

        public Book(string s)
        {
            string[] inp = s.Split();

            this.Title = inp[0];
            this.Author = inp[1];
            this.Publisher = inp[2];
            string[] dateFormats = new string[] { "d.M.yyyy", "d.MM.yyyy", "dd.M.yyyy", "dd.MM.yyyy" };
            this.ReleaseDate = DateTime.ParseExact(inp[3], dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            this.ISBN = inp[4];
            this.Price = double.Parse(inp[5]);
        }
    }
}
