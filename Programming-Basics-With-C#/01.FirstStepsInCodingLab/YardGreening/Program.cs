using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double yards = double.Parse(Console.ReadLine());

            double priceForOneYard = 7.61;
            double precentageDiscount = (yards * priceForOneYard) * 0.18;

            double totalPrice = (yards * priceForOneYard) - precentageDiscount;

            Console.WriteLine($"The final price is: {totalPrice} lv.");
            Console.WriteLine($"The discount is: {precentageDiscount} lv.");
        }
    }
}
