using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());
            Engine engine = new Engine(560, 6300);
            Tire[] tires = new Tire[4]
                {
                    new Tire(1, 2.5),
                    new Tire(1, 2.5),
                    new Tire(1, 2.5),
                    new Tire(1, 2.5)
                };

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            Car forthCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

            Console.WriteLine($"Make: {forthCar.Make},\nModel: {forthCar.Model},\nYear: {forthCar.Year},\nHP: {forthCar.Engine.HorsePower},\nCubicCapacity: {forthCar.Engine.CubicCapacity}");

            foreach (Tire tire in forthCar.Tires)
            {
                Console.WriteLine(tire.Year);
                Console.WriteLine(tire.Pressure);
            }
        }
    }
}
