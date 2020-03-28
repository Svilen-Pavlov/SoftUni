using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06._Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = Console.ReadLine().Split().ToList();

            input.RemoveAll(x => x.Length != 2);
            input.Reverse();
            for (int i = 0; i < input.Count; i++)
            {

                char hexchar = 'a';
                if (int.TryParse(input[i], out int num) == true)
                {
                    int edinici = num % 10;
                    int tens = (num - edinici) / 10;
                    int res = edinici * 10 + tens;
                    input[i] = res.ToString();
                    hexchar = (char)Int16.Parse(input[i], NumberStyles.AllowHexSpecifier);
                }
                else
                {
                    char one = input[i][0];
                    char two = input[i][1];
                    char temp = one;
                    one = two;
                    two = temp;
                    input[i] = one.ToString() + two;
                    int value = Convert.ToInt32(input[i], 16);
                    char charValue = (char)value;
                    hexchar = charValue;
                }
                Console.Write(hexchar);
            }
            Console.WriteLine();
        }
    }
}
