using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (Fuel - neededFuel >= 0)
            {
                Fuel -= neededFuel;
            }
        }
    }
}
