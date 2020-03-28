using System;
using System.Collections.Generic;

namespace _07._Andrey_and_Billiard
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Bar theBar = new Bar();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Product currProd = new Product(input);
                theBar.AddProd(currProd);
            }

            string input2 = Console.ReadLine();

            while (input2 != "end of clients")
            {
                Client currClient = new Client(input2);
                if (theBar.Inventory.ContainsKey(currClient.BoughtProduct)) //only if product exists
                {
                    if (theBar.ClientsBills.ContainsKey(currClient.Name) == false) //new client
                    {
                        currClient.Basket.Add(currClient.BoughtProduct, currClient.Quantity);
                        theBar.ClientsBills.Add(currClient.Name, currClient);
                    }
                    else //old client
                    {

                        if (theBar.ClientsBills[currClient.Name].Basket.ContainsKey(currClient.BoughtProduct) == false) // new product
                        {
                            theBar.ClientsBills[currClient.Name].Basket.Add(currClient.BoughtProduct, currClient.Quantity);
                        }
                        else
                        {
                            theBar.ClientsBills[currClient.Name].Basket[currClient.BoughtProduct] += currClient.Quantity;
                        }
                    }
                }
                input2 = Console.ReadLine(); //renew
            }
            theBar.PrintBills();
        }
    }

    class Client
    {
        public string Name { get; set; }
        public string BoughtProduct { get; set; }
        public double Quantity { get; set; }
        public double Bill { get; set; }
        public Dictionary<string, double> Basket { get; set; }

        public Client(string s)
        {
            string[] arr = s.Split(new char[] { '-', ',' });
            this.Name = arr[0];
            this.BoughtProduct = arr[1];
            this.Quantity = double.Parse(arr[2]);
            this.Bill = 0;
            this.Basket = new Dictionary<string, double>();
        }
    }

    class Bar
    {
        public Dictionary<string, Product> Inventory { get; set; }
        public SortedDictionary<string, Client> ClientsBills = new SortedDictionary<string, Client>();

        public Bar()
        {
            this.Inventory = new Dictionary<string, Product>();
        }
        public void AddProd(Product currProd)
        {
            if (Inventory.ContainsKey(currProd.Name) == false)
            {
                Inventory.Add(currProd.Name, currProd);
            }
            else
            {
                Inventory[currProd.Name].Price = currProd.Price;
            }
        }

        internal void PrintBills()
        {
            double GrandTotal = 0;
            foreach (var entry in ClientsBills) // every client has a basket
            {
                Console.WriteLine(entry.Key);//client name
                Client currCl = entry.Value;//summing client individual bill
                double sumBasket = 0;
                foreach (var product in currCl.Basket)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                    sumBasket += product.Value * Inventory[product.Key].Price;
                }
                currCl.Bill = sumBasket;
                Console.WriteLine($"Bill: {sumBasket:f2}");
                GrandTotal += currCl.Bill;
            }
            Console.WriteLine($"Total bill: {GrandTotal:f2}");

        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string s)
        {
            string[] arr = s.Split('-');
            this.Name = arr[0];
            this.Price = double.Parse(arr[1]);
        }
    }
}
