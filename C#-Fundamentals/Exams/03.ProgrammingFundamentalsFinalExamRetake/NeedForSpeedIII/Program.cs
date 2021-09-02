using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    public class Car
    {
        private const int MaxFuel = 75;
        private const int MinMileage = 10000;

        public Car(string model, int mileage, int fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Model { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public void Drive(int distance, int requiredFuel)
        {
            if (Fuel >= requiredFuel)
            {
                Fuel -= requiredFuel;
                Mileage += distance;

                Console.WriteLine($"{Model} driven for {distance} kilometers. {requiredFuel} liters of fuel consumed.");
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
        }

        public void Refuel(int fuelAmount)
        {
            if (Fuel + fuelAmount > MaxFuel)
            {
                fuelAmount = MaxFuel - Fuel;
            }

            Fuel += fuelAmount;

            Console.WriteLine($"{Model} refueled with {fuelAmount} liters");
        }

        public void Revert(int kilometers)
        {
            if (Mileage - kilometers >= MinMileage)
            {
                Mileage -= kilometers;

                Console.WriteLine($"{Model} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                Mileage = MinMileage;
            }
        }

        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandData = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string model = commandData[0];
                int mileage = int.Parse(commandData[1]);
                int fuel = int.Parse(commandData[2]);

                if (!cars.ContainsKey(model))
                {
                    Car car = new Car(model, mileage, fuel);

                    cars.Add(model, car);
                }
            }

            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string[] commandData = line
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string model = commandData[1];

                if (cars.ContainsKey(model))
                {
                    if (command == "Drive")
                    {
                        int distance = int.Parse(commandData[2]);
                        int requiredFuel = int.Parse(commandData[3]);

                        cars[model].Drive(distance,requiredFuel);

                        if (cars[model].Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {model}!");
                            cars.Remove(model);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        int fuelAmount = int.Parse(commandData[2]);

                        cars[model].Refuel(fuelAmount);
                    }
                    else if (command == "Revert")
                    {
                        int kilometers = int.Parse(commandData[2]);

                        cars[model].Revert(kilometers);
                    }
                }

                line = Console.ReadLine();
            }

            cars = cars
                .OrderByDescending(c => c.Value.Mileage)
                .ThenBy(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Value);

            Console.WriteLine(string.Join(Environment.NewLine, cars.Values));
        }
    }
}
