using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Car
    {
        public Car(string model, string color, double horsePower)
        {
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public double HorsePower { get; set; }

        public override string ToString()
        {
            //Type: { typeOfVehicle}
            //Model: { modelOfVehicle}
            //Color: { colorOfVehicle}
            //Horsepower: { horsepowerOfVehicle}


            return $"Type: {GetType().Name}\nModel: {Model}\nColor: {Color}\nHorsepower: {HorsePower}";
        }
    }

    class Truck : Car
    {
        public Truck(string model, string color, double horsePower) : base(model, color, horsePower)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            double averageCarsHp = 0;
            double averageTrucksHp = 0;

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] vehicleData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                double horsePower = double.Parse(vehicleData[3]);

                if (type == "car")
                {
                    Car car = new Car(model, color, horsePower);

                    cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck(model, color, horsePower);

                    trucks.Add(truck);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "Close the Catalogue")
            {
                foreach (var car in cars)
                {
                    if (car.Model == line)
                    {
                        Console.WriteLine(car);
                        break;
                    }
                }

                foreach (var truck in trucks)
                {
                    if (truck.Model == line)
                    {
                        Console.WriteLine(truck);
                        break;
                    }
                }

                line = Console.ReadLine();
            }

            if (cars.Any())
            {
                averageCarsHp = cars.Average(c => c.HorsePower);

            }
            Console.WriteLine($"Cars have average horsepower of: {averageCarsHp:f2}.");

            if (trucks.Any())
            {
                averageTrucksHp = trucks.Average(c => c.HorsePower);
            }

            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHp:f2}.");
        }
    }
}
