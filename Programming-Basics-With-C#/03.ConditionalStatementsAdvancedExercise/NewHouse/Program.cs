using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double pricePerFlower = 0;

            switch (typeFlower)
            {
                case "Roses":
                    pricePerFlower = 5;
                    break;
                case "Dahlias":
                    pricePerFlower = 3.8;
                    break;
                case "Tulips":
                    pricePerFlower = 2.8;
                    break;
                case "Narcissus":
                    pricePerFlower = 3;
                    break;
                case "Gladiolus":
                    pricePerFlower = 2.5;
                    break;


                default:
                    break;
            }

            double totalPrice = pricePerFlower * countFlowers;

            if (countFlowers > 80 && typeFlower == "Roses")
            {
                totalPrice = totalPrice - (totalPrice * 0.1);
            }
            else if (countFlowers > 90 && typeFlower == "Dahlias")
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (countFlowers > 80 && typeFlower == "Tulips")
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (countFlowers < 120 && typeFlower == "Narcissus")
            {
                totalPrice = totalPrice + (totalPrice * 0.15);
            }
            else if (countFlowers < 80 && typeFlower == "Gladiolus")
            {
                totalPrice = totalPrice + (totalPrice * 0.20);
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {typeFlower} and {(budget - totalPrice):f2} leva left.");
            }
            else if (totalPrice > budget)
            {
                Console.WriteLine($"Not enough money, you need {(totalPrice - budget):f2} leva more.");
            }
        }
    }
}
