using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        protected double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (TankCapacity >= value)
                {
                    fuelQuantity = value;
                }
                else
                {
                    fuelQuantity = 0;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public abstract double AirConditionerConsumption { get; }

        public double TankCapacity { get; private set; }

        public virtual void Drive(double distance)
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
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
