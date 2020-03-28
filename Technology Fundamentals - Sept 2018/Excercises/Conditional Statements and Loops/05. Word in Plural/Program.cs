using System;

namespace _05._Word_in_Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string neword;
            bool endsinY = word.EndsWith("y");
            bool endsinO = word.EndsWith("o");
            bool endsinCH = word.EndsWith("ch");
            bool endsinS = word.EndsWith("s");
            bool endsinSH = word.EndsWith("sh");
            bool endsinX = word.EndsWith("x");
            bool endsinZ = word.EndsWith("z");

            int lenght = word.Length;
            if (endsinO || endsinCH || endsinS || endsinSH || endsinX || endsinZ)
            {
                word = word + "es";
                Console.WriteLine(word);
            }
            else if (endsinY)
            {

                neword = word.Remove(lenght - 1);//tuka e mahaneto
                neword = neword + "ies";
                Console.WriteLine(neword);
            }
            else
            {
                word = word + "s";
                Console.WriteLine(word);
            }
        }
    }
}
