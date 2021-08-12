using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberriesKg = double.Parse(Console.ReadLine());
            double strawberriesKg = double.Parse(Console.ReadLine());

            double raspberriesPrice = strawberriesPrice / 2;
            double orangesPrice = raspberriesPrice * 0.6;
            double bananasPrice = raspberriesPrice * 0.2;

            double totalPrice = strawberriesPrice * strawberriesKg + bananasPrice * bananasKg + orangesPrice * orangesKg + raspberriesPrice * raspberriesKg;

            Console.WriteLine(totalPrice);
        }
    }
}
