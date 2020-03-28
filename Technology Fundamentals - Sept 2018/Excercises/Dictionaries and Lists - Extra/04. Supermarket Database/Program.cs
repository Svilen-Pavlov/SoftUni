using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Supermarket_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> proQty = new Dictionary<string, int>();
            Dictionary<string, double> proPrice = new Dictionary<string, double>();

            while (input != "stocked" && input != "Stocked")
            {
                string product = input.Split().ToArray()[0];
                double price = double.Parse(input.Split().ToArray()[1]);
                int qty = int.Parse(input.Split().ToArray()[2]);

                if (proQty.ContainsKey(product) == false) //no product
                {
                    proQty.Add(product, qty);
                    proPrice.Add(product, price);
                }
                else //has product
                {
                    proQty[product] += qty;
                    if (proPrice[product] != price)
                    {
                        proPrice[product] = price;

                    }

                }
                input = Console.ReadLine();
            }
            double total = 0;
            foreach (var product in proQty)
            {
                double price = proPrice[product.Key];
                int qty = proQty[product.Key];
                double sum = price * qty;
                total += sum;
                Console.WriteLine($"{product.Key}: ${price:f2} * {product.Value} = ${sum:f2}");
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Grand Total: ${total:f2}");
        }
    }
}
