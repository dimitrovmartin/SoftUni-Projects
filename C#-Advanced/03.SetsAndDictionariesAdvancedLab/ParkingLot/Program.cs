using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> licencePlates = new HashSet<string>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] commandData = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string licencePlate = commandData[1];

                if (command == "IN")
                {
                    licencePlates.Add(licencePlate);
                }
                else if (command == "OUT")
                {
                    if (licencePlates.Contains(licencePlate))
                    {
                        licencePlates.Remove(licencePlate);
                    }
                }

                line = Console.ReadLine();
            }

            if (licencePlates.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, licencePlates));
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
