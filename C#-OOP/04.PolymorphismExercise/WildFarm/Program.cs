using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] animalData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = CreateAnimal(animalData);
                Console.WriteLine(animal.ProduceSound());

                animals.Add(animal);

                string[] foodData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Food food = CreateFood(foodData);

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodData)
        {
            string type = foodData[0];
            int quantity = int.Parse(foodData[1]);

            if (type == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else
            {
                return new Seeds(quantity);
            }
        }

        private static Animal CreateAnimal(string[] animalData)
        {
            string type = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalData[3]);

                return new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalData[3]);

                return new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalData[3];

                return new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalData[3];

                return new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];

                return new Cat(name, weight, livingRegion, breed);
            }
            else
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];

                return new Tiger(name, weight, livingRegion, breed);
            }
        }
    }
}
