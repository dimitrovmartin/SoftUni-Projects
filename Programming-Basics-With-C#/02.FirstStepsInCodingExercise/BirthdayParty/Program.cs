using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rentPrice = double.Parse(Console.ReadLine());

            double cakePrice = rentPrice * 0.2;
            double drinksPrice = cakePrice * 0.55;
            double animatorPrice = rentPrice / 3;

            double totalPrice = rentPrice + cakePrice + drinksPrice + animatorPrice;

            Console.WriteLine(totalPrice);
        }
    }
}
