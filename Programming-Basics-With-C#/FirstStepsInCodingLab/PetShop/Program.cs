using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogCount = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            double dogFoodPrice = 2.5;
            double otherAnimalsPrice = 4;

            double totalPrice = dogCount * dogFoodPrice + otherAnimals * otherAnimalsPrice;

            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
