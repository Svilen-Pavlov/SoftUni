using System;
using System.Globalization;

namespace _01._Count_Working_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDate1 = Console.ReadLine();
            string inputDate2 = Console.ReadLine();


            DateTime date = DateTime.ParseExact(inputDate1, "dd-MM-yyyy", CultureInfo.InstalledUICulture);
            DateTime date2 = DateTime.ParseExact(inputDate2, "dd-MM-yyyy", CultureInfo.InstalledUICulture);
            int result = 1;
            //string[] holidays = new string[] { "1-01", "3-03", "1-05", "6-05", "24-05", "6-09", "22-09", "1-11", "24-12", "25-12", "26-12" };


            for (DateTime i = date; i < date2; i = i.AddDays(1))
            {
                string toCheck = (i.Day.ToString() + "-" + i.Month);
                //Console.WriteLine(toCheck);
                bool cont = true;
                if (toCheck == "1-1" || toCheck == "3-3" || toCheck == "1-5" || toCheck == "6-5" || toCheck == "24-5"
                    || toCheck == "6-9" || toCheck == "22-9" || toCheck == "1-11" || toCheck == "24-12" || toCheck == "25-12" || toCheck == "26-12")
                {
                    cont = false;
                }


                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday && cont == true)
                {
                    result++;

                }
            }
            Console.WriteLine(result);
        }
    }
}
