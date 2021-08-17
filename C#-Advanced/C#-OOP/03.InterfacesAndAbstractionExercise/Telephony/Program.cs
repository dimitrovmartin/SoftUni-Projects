using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                }
                else
                {
                    smartphone.Call(number);
                }
            }

            foreach (var url in urls)
            {
                smartphone.Browse(url);
            }
        }
    }
}
