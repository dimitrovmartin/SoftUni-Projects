using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> plateByName = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] licensePlateData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = licensePlateData[0];
                string name = licensePlateData[1];

                if (command == "register")
                {
                    string licensePlate = licensePlateData[2];

                    if (!plateByName.ContainsKey(name))
                    {
                        plateByName.Add(name, licensePlate);

                        Console.WriteLine($"{name} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                }
                else if (command == "unregister")
                {
                    if (plateByName.ContainsKey(name))
                    {
                        plateByName.Remove(name);

                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var kvp in plateByName)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
