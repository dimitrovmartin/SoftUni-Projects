using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public abstract double AirConditionerConsumption { get; }

        public void Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + AirConditionerConsumption) * distance;

            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeeded;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");

        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
