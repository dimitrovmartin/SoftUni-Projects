using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] animalData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];

                Animal animal;

                if (age > 0)
                {
                    if (animalType == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (animalType == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (animalType == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");

                        animalType = Console.ReadLine();

                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");

                    animalType = Console.ReadLine();

                    continue;
                }

                animals.Add(animal);

                animalType = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }
    }
}
