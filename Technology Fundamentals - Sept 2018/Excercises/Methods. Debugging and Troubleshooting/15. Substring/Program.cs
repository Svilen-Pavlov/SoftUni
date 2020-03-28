using System;

namespace _15._Substring
{
    class Program
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            bool hasMatch = false;
            int jumpcount = 1;
            for (int i = 0; i < text.Length; i++)
            {
                char[] textArr = text.ToCharArray();

                if (textArr[i] == 'p') // text[i] == Search
                {
                    hasMatch = true;

                    int length = jump + 1;
                    jumpcount++;
                    if (length + i >= text.Length)
                    {
                        length = text.Length - i;
                    }

                    string matchedString = text.Substring(i, length);
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }

        }
    }
}
