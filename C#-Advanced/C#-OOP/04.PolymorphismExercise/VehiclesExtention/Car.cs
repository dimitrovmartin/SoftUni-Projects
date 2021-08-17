using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double DefaultAirConditionerConsumption = 0.9;

        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double AirConditionerConsumption => DefaultAirConditionerConsumption;
    }
}
