using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countCarsCouldPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int carsPassed = 0;

            string line = Console.ReadLine();

            while (line != "end")
            {
                if (line == "green")
                {
                    for (int i = 0; i < countCarsCouldPass; i++)
                    {
                        if (cars.Any())
                        {
                            string currentCar = cars.Dequeue();

                            Console.WriteLine($"{currentCar} passed!");

                            carsPassed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(line);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
