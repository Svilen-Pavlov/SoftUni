using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Parking_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> db = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string action = input.Split().ToArray()[0];
                string username = input.Split().ToArray()[1];
                if (action == "register")
                {
                    string plate = input.Split().ToArray()[2];
                    bool plateValid = ValidPlate(plate);

                    if (db.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {db[username]}");
                    }
                    else if (plateValid == false)
                    {
                        Console.WriteLine($"ERROR: invalid license plate {plate}");

                    }
                    else
                    {
                        if (db.ContainsKey(username) == false) // new user
                        {
                            if (db.ContainsValue(plate))// existing plate
                            {
                                Console.WriteLine($"ERROR: license plate {plate} is busy");
                            }
                            else
                            {
                                db.Add(username, plate);
                                Console.WriteLine($"{username} registered {plate} successfully");
                            }

                        }


                    }
                }
                else if (action == "unregister")
                {
                    if (db.ContainsKey(username) == false)
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"user {username} unregistered successfully");
                        db.Remove(username);
                    }
                }

            }

            foreach (var entry in db)
            {
                Console.WriteLine($"{entry.Key} => {entry.Value}");
            }

        }

        private static bool ValidPlate(string plate)
        {
            bool result = true;
            if (plate.Length != 8)
            {
                return false;
            }
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == 2)
                {
                    counter = 6;
                }
                if (plate[counter] < 65 || plate[counter] > 90)
                {
                    return false;
                }
                counter++;
            }
            for (int i = 2; i < 6; i++)
            {
                if (plate[i] < 48 || plate[i] > 57)
                {
                    return false;
                }
            }


            return result;
        }
    }
}
