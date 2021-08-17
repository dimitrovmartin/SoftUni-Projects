using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                ExecuteTheCommand(car, truck);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteTheCommand(Vehicle car, Vehicle truck)
        {
            string[] commandParts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandParts[0];
            string vehicle = commandParts[1];
            double modifier = double.Parse(commandParts[2]);

            if (command == "Drive")
            {
                try
                {
                    if (vehicle == nameof(Car))
                    {
                        car.Drive(modifier);
                    }
                    else
                    {
                        truck.Drive(modifier);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (command == "Refuel")
            {
                if (vehicle == nameof(Car))
                {
                    car.Refuel(modifier);
                }
                else
                {
                    truck.Refuel(modifier);
                }
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleData[0];
            double fuelQuantity = double.Parse(vehicleData[1]);
            double fuelConsumption = double.Parse(vehicleData[2]);

            if (type == nameof(Car))
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }
        }
    }
}
