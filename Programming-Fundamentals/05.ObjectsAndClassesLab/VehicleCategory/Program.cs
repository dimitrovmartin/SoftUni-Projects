using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue 
{
    public class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }
    }
    public class Car
    {
        public Car(string brand, string model, double horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }
    public class Truck
    {
        public Truck(string brand, string model, double weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] vehicleData = line
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                string vehicle = vehicleData[0];
                string brand = vehicleData[1];
                string model = vehicleData[2];

                if (vehicle == "Car")
                {
                    double horsePower = double.Parse(vehicleData[3]);

                    Car car = new Car(brand, model, horsePower);

                    catalog.Cars.Add(car);
                }
                else
                {
                    double weight = double.Parse(vehicleData[3]);

                    Truck truck = new Truck(brand, model, weight);

                    catalog.Trucks.Add(truck);
                }

                line = Console.ReadLine();
            }

            catalog.Cars = catalog.Cars.OrderBy(c => c.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(t => t.Brand).ToList();

            if (catalog.Cars.Any())
            {
                Console.WriteLine($"Cars:");

                foreach (var car in catalog.Cars)
                {
                    Console.WriteLine(car);
                }
            }

            if (catalog.Trucks.Any())
            {
                Console.WriteLine($"Trucks:");

                foreach (var truck in catalog.Trucks)
                {
                    Console.WriteLine(truck);
                }
            }
        }
    }
}
