using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] adressData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string personName = adressData[0] + ' ' + adressData[1];
            string adress = adressData[2];
            string town = string.Join(" ", adressData.Skip(3));

            GenericThreeuple<string, string, string> addressByPerson = new GenericThreeuple<string, string, string>(personName, adress, town);

            string[] beerData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            personName = beerData[0];
            int drinkedBeers = int.Parse(beerData[1]);
            bool isDrunk = beerData[2] == "drunk" ? true : false;

            GenericThreeuple<string, int, bool> drinkedBeersByPerson = new GenericThreeuple<string, int, bool>(personName, drinkedBeers, isDrunk);

            string[] bankData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            personName = bankData[0];
            double balance = double.Parse(bankData[1]);
            string bankName = bankData[2];

            GenericThreeuple<string, double, string> balanceByPerson = new GenericThreeuple<string, double, string>(personName, balance, bankName);

            Console.WriteLine(addressByPerson);
            Console.WriteLine(drinkedBeersByPerson);
            Console.WriteLine(balanceByPerson);
        }
    }
}
