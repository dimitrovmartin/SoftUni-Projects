using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            double precentage = 0;
            double price = 0;

            switch (room)
            {
                case "apartment":
                    if (days < 10)
                    {
                        precentage = 0.3;
                        price = 25;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        precentage = 0.35;
                        price = 25;
                    }
                    else if (days > 15)
                    {
                        precentage = 0.5;
                        price = 25;
                    }
                    break;

                case "president apartment":
                    if (days < 10)
                    {
                        precentage = 0.1;
                        price = 35;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        precentage = 0.15;
                        price = 35;
                    }
                    else if (days > 15)
                    {
                        precentage = 0.2;
                        price = 35;
                    }
                    break;
                case "room for one person":
                    price = 18;
                    break;

                default:
                    break;

            }
            double total = ((days - 1) * price);

            total -= total * precentage;

            if (rating == "positive")
            {
                total += total * 0.25;
            }
            else if (rating == "negative")
            {
                total -= total * 0.1;
            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
