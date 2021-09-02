using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            int carsPassed = 0;

            string hittedCar = string.Empty;
            int hittedCharIndex = 0;

            bool isCrashHappened = false;

            Queue<string> cars = new Queue<string>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                if (line == "green")
                {
                    int currentGreenLightDuration = greenLightDuration;

                    while (currentGreenLightDuration != 0 && cars.Any())
                    {
                        string currentCar = cars.Dequeue();

                        if (currentGreenLightDuration - currentCar.Length >= 0)
                        {
                            currentGreenLightDuration -= currentCar.Length;

                            carsPassed++;
                        }
                        else
                        {
                            if (currentGreenLightDuration + freeWindowDuration >= currentCar.Length)
                            {
                                carsPassed++;
                                currentGreenLightDuration = 0;
                            }
                            else
                            {
                                hittedCar = currentCar;
                                hittedCharIndex = currentGreenLightDuration + freeWindowDuration;

                                isCrashHappened = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(line);
                }

                if (isCrashHappened)
                {
                    break;
                }

                line = Console.ReadLine();
            }

            if (isCrashHappened)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCar} was hit at {hittedCar[hittedCharIndex]}.");
            }
            else
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
