using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                Engine engine = new Engine(model, power);

                if (engineData.Length == 3)
                {
                    if (Char.IsDigit(engineData[2][0]))
                    {
                        string displacement = engineData[2];
                        engine.Displacement = displacement;

                    }
                    else
                    {
                        string efficiency = engineData[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (engineData.Length == 4)
                {
                    string displacement = engineData[2];
                    string efficiency = engineData[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string model = carData[0];
                string engineModel = carData[1];
                Engine engine = engines.First(e => e.Model == engineModel);

                Car car = new Car(model, engine);

                if (carData.Length == 3)
                {
                    if (Char.IsDigit(carData[2][0]))
                    {
                        string weight = carData[2];
                        car.Weight = weight;

                    }
                    else
                    {
                        string color = carData[2];
                        car.Color = color;
                    }
                }
                else if (carData.Length == 4)
                {
                    string weight = carData[2];
                    string color = carData[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
