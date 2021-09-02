using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> totalTires = new List<Tire[]>();
            List<Engine> totalEngines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string line = Console.ReadLine();

            while (line != "No more tires")
            {
                string[] tiresData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tire> tires = new List<Tire>();

                for (int i = 0; i < 8; i += 2)
                {
                    int year = int.Parse(tiresData[i]);
                    double pressure = double.Parse(tiresData[i + 1]);

                    Tire tire = new Tire(year, pressure);

                    tires.Add(tire);
                }

                totalTires.Add(tires.ToArray());

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "Engines done")
            {
                string[] engineData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                totalEngines.Add(engine);

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "Show special")
            {
                string[] carData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                Engine engine = totalEngines[engineIndex];
                Tire[] tires = totalTires[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

                cars.Add(car);

                line = Console.ReadLine();
            }

            cars = cars
                .Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
