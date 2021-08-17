using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double DefaultAirConditionerConsumption = 1.6;

        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double AirConditionerConsumption => DefaultAirConditionerConsumption;

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }

            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += fuel * 0.95;
        }
    }
}
