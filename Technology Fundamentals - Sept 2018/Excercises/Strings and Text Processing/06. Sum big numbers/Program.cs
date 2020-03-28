using System;
using System.Text;

namespace _06._Sum_big_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder num1 = new StringBuilder(Console.ReadLine().TrimStart(new char[] { '0' }));
            StringBuilder num2 = new StringBuilder(Console.ReadLine().TrimStart(new char[] { '0' }));
            int len1 = num1.Length;
            int len2 = num2.Length;
            StringBuilder result = new StringBuilder();
            int inMind = 0;
            int prevInMind = 0;

            for (int i = 0; i < Math.Min(len1, len2); i++)
            {

                int lastOne = int.Parse(num1[len1 - 1 - i].ToString());
                int lastTwo = int.Parse(num2[len2 - 1 - i].ToString());
                int sum = lastOne + lastTwo;
                int digitToAdd = 0;

                //defining digitToAdd
                if (sum >= 10)
                {
                    inMind = 1;
                    digitToAdd = (sum % 10);
                }
                else
                {
                    digitToAdd = sum;
                }

                //adding to stringB, accounting for 1 inMind
                if (prevInMind == 0)
                {
                    result.Insert(0, digitToAdd.ToString());
                }
                else if (prevInMind == 1)
                {
                    digitToAdd++;
                    if (digitToAdd == 10)
                    {
                        digitToAdd = 1;
                        result.Insert(0, digitToAdd.ToString());
                    }
                    else
                    {
                        result.Insert(0, digitToAdd.ToString());
                    }
                }
                num1.Remove(len1 - 1 - i, 1);
                num2.Remove(len2 - 1 - i, 1);
                prevInMind = inMind;
                inMind = 0;
            }
            if (len1 != len2)
            {
                StringBuilder leftover = new StringBuilder();
                if (len1 > len2)
                {
                    leftover.Append(num1);
                }
                else if (len2 > len1)
                {
                    leftover.Append(num2);
                }
                int len3 = leftover.Length;

                int lastLeftOver = int.Parse(leftover[len3 - 1].ToString());
                lastLeftOver += prevInMind;
                int counter = 0;
                if (lastLeftOver == 10)
                {
                    while (lastLeftOver == 10) //1+9999
                    {
                        leftover.Remove(len3 - 1 - counter, 1);
                        leftover.Append(0);
                        prevInMind = 1;
                        counter++;
                        if (len3 - 1 - counter < 0)
                        {
                            leftover.Insert(0, 1);
                            break;
                        }
                        else
                        {
                            lastLeftOver = int.Parse(leftover[len3 - 1 - counter].ToString()) + prevInMind;
                        }
                    }
                }
                else
                {
                    leftover.Remove(leftover.Length - 1, 1);
                    leftover.Append(lastLeftOver.ToString());
                }
                result.Insert(0, leftover);
            }
            Console.WriteLine(result);

        }
    }
}
