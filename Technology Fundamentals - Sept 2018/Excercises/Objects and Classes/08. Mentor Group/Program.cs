using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08._Mentor_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> list = new List<Student>();
            while (input != "end of dates")
            {
                Student currS = new Student(input);
                bool uni = true;
                int indexD = int.MaxValue;
                foreach (var student in list)
                {
                    if (currS.Name == student.Name)
                    {
                        uni = false;
                        indexD = list.IndexOf(student);
                        AppendDates(input, list, indexD);
                        break;
                    }
                }
                if (uni == true)
                {
                    list.Add(currS);
                }


                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "end of comments")
            {
                string[] arr = input.Split('-');
                foreach (var student in list)
                {
                    if (student.Name == arr[0])
                    {
                        student.Comments.Add(arr[1]); break;
                    }

                }

                input = Console.ReadLine();//renew
            }
            Print(list);
        }

        private static void Print(List<Student> list)
        {
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach (var student in list)
            {
                Console.WriteLine($"{student.Name}");

                Console.WriteLine($"Comments:");
                foreach (var comment in student.Comments)
                {
                    Console.WriteLine("- " + comment);
                }

                Console.WriteLine($"Dates attended:");
                student.Dates.Sort();
                foreach (var date in student.Dates)
                {
                    Console.WriteLine("-- " + date.ToString("dd/MM/yyyy"));
                }
            }
        }

        class Student
        {
            public string Name { get; set; }
            public List<DateTime> Dates { get; set; }
            public List<string> Comments { get; set; }
            public Student(string input)
            {
                string[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                this.Name = arr[0];
                this.Dates = new List<DateTime>();
                if (arr.Length > 1)
                {
                    this.Dates.AddRange(arr.Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).Skip(1));
                }
                this.Comments = new List<string>();

            }

        }
        private static void AppendDates(string s, List<Student> list, int indexD)
        {
            string[] arr = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string name = arr[0];
            Student curr = list[indexD];
            curr.Dates.AddRange(arr.Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).Skip(1));
        }
    }
}
