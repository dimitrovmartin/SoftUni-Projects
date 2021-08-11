using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }

        public int Capacity { get => capacity; set => capacity = value; }
        public List<Car> Cars { get => cars; set => cars = value; }
        public int Count => this.Cars.Count();

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return  $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car car = cars.First(c => c.RegistrationNumber == registrationNumber);
                cars.Remove(car);

                return $"Successfully removed {registrationNumber}";
            }
        }
        
        public Car GetCar(string registrationNumber)
        {
            Car car = cars.First(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                if (cars.Any(c => c.RegistrationNumber == registrationNumber))
                {
                    Car car = cars.First(c => c.RegistrationNumber == registrationNumber);

                    cars.Remove(car);
                }
            }
        }
    }
}
