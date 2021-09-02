using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                ExecuteTheCommand(car, truck, bus);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ExecuteTheCommand(Vehicle car, Vehicle truck, Vehicle bus)
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
                    else if (vehicle == nameof(Truck))
                    {
                        truck.Drive(modifier);
                    }
                    else if (vehicle == nameof(Bus))
                    {
                        bus.Drive(modifier);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (command == "Refuel")
            {
                try
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
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (command == "DriveEmpty")
            {
                try
                {
                    ((Bus)bus).DriveEmpty(modifier);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
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
            double tankCapacity = double.Parse(vehicleData[3]);

            if (type == nameof(Car))
            {
                return new Car(tankCapacity, fuelQuantity, fuelConsumption);
            }
            else if (type == nameof(Truck))
            {
                return new Truck(tankCapacity, fuelQuantity, fuelConsumption);
            }
            else
            {
                return new Bus(tankCapacity, fuelQuantity, fuelConsumption);
            }
        }
    }
}
