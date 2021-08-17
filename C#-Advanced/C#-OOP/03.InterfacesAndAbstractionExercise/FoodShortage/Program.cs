using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] buyerData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = buyerData[0];
                int age = int.Parse(buyerData[1]);

                if (buyerData.Length == 4)
                {
                    string id = buyerData[2];
                    string birthdate = buyerData[3];

                    IBuyer buyer = new Citizen(name, age, id, birthdate);

                    buyers.Add(name, buyer);
                }
                else if (buyerData.Length == 3)
                {
                    string group = buyerData[2];

                    IBuyer buyer = new Rebel(name, age, group);

                    buyers.Add(name, buyer);
                }
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                if (buyers.ContainsKey(line))
                {
                    buyers[line].BuyFood();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Value.Food));
        }
    }
}
