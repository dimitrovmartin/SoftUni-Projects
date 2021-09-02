using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double AirConditionerConsumption => 1.4;

        public override void Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + AirConditionerConsumption) * distance;

            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeeded;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;

            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeeded;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
    }
}
