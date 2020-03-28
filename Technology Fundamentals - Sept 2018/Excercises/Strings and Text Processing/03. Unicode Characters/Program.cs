using System;
using System.Text;

namespace _03._Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            foreach (var cha in input.ToString())
            {
                result.AppendFormat("\\u{0:X4}", (uint)cha);
            }
            foreach (var cha in result.ToString())
            {
                if (cha > 64 && cha < 91)
                {
                    result.Replace(cha, (char)(cha + 32));
                }
            }
            Console.WriteLine(string.Join("\\", result));
        }
    }
}
