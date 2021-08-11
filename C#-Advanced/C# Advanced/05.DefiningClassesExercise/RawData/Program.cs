using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string model = carData[0];
                double engineSpeed = double.Parse(carData[1]);
                double enginePower = double.Parse(carData[2]);
                double cargoWeight = double.Parse(carData[3]);
                string cargoType = carData[4];
                double firstTirePressure = double.Parse(carData[5]);
                int firstTireYear = int.Parse(carData[6]);
                double secondTirePressure = double.Parse(carData[7]);
                int secondTireYear = int.Parse(carData[8]);
                double thirdTirePressure = double.Parse(carData[9]);
                int thirdTireYear = int.Parse(carData[10]);
                double fourthTirePressure = double.Parse(carData[11]);
                int fourthTireYear = int.Parse(carData[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[]
                {
                    new Tire(firstTirePressure,firstTireYear),
                    new Tire(secondTirePressure, secondTireYear),
                    new Tire(thirdTirePressure, thirdTireYear),
                    new Tire(fourthTirePressure, fourthTireYear),
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string neededCargoType = Console.ReadLine();

            if (neededCargoType == "fragile")
            {
                cars = cars
                  .Where(c => c.Cargo.Type == neededCargoType &&
                  c.Tires.Any(t => t.Pressure < 1))
                  .ToList();
            }
            else
            {
                cars = cars
                 .Where(c => c.Cargo.Type == neededCargoType &&
                 c.Engine.Power > 250)
                 .ToList();
            }



            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
