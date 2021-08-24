using System;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] adressData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string personName = adressData[0] + ' ' + adressData[1];
            string adress = adressData[2];

            GenericTuple<string, string> addressByPerson = new GenericTuple<string, string>(personName, adress);

            string[] beerData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            personName = beerData[0];
            int drinkedBeers = int.Parse(beerData[1]);

            GenericTuple<string, int> drinkedBeersByPerson = new GenericTuple<string, int>(personName, drinkedBeers);

            double[] numbersData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            int integer = (int)numbersData[0];
            double @double = numbersData[1];

            GenericTuple<int, double> integerToDouble = new GenericTuple<int, double>(integer, @double);

            Console.WriteLine(addressByPerson);
            Console.WriteLine(drinkedBeersByPerson);
            Console.WriteLine(integerToDouble);
        }
    }
}
