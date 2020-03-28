using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> gradeBook = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                Student currStud = new Student(Console.ReadLine());
                if (currStud.AvgGrade >= 5.00)
                {
                    gradeBook.Add(currStud);

                }

            }

            foreach (var entry in gradeBook.OrderBy(x => x.Name).ThenByDescending(x => x.AvgGrade))
            {
                Console.WriteLine($"{entry.Name} -> {entry.AvgGrade:f2}");
            }


        }

        class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double AvgGrade { get; set; }

            public Student(string s)
            {

                string[] currInput = s.Split();
                this.Name = currInput[0];
                this.Grades = new List<double>();
                Grades.AddRange(currInput.Select(double.Parse).Skip(1));
                this.AvgGrade = Grades.Average();
            }

        }
    }
}
