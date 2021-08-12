using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int personsPerElevator = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling((double)persons / personsPerElevator));
        }
    }
}
